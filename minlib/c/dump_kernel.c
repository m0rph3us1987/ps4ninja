/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#include "../include/minlib.h"

#define PKT_SIZE 4096
#define NULL 0

enum	uio_rw { UIO_READ, UIO_WRITE };

/* Segment flag values. */
enum uio_seg {
	UIO_USERSPACE,		/* from user data space */
	UIO_SYSSPACE,		/* from system space */
	UIO_NOCOPY		/* don't copy, already in object */
};

struct iovec {
	void	*iov_base;	/* Base address. */
	size_t	 iov_len;	/* Length. */
};

struct uio {
	     struct  iovec *uio_iov;	     /*	scatter/gather list */
	     int     uio_iovcnt;	     /*	length of scatter/gather list */
	     off_t   uio_offset;	     /*	offset in target object	*/
	     ssize_t uio_resid;		     /*	remaining bytes	to copy	*/
	     enum    uio_seg uio_segflg;     /*	address	space */
	     enum    uio_rw uio_rw;	     /*	operation */
	     struct  thread *uio_td;	     /*	owner */
};

int socketSendKernel(struct thread *td, struct socket *sock, const void *data, size_t size)
{
	int (*sosend) (struct socket *so, struct sockaddr *addr, struct uio *uio, struct mbuf *top, struct mbuf *control, int flags, struct thread *td);
	sosend = resolve_function("sosend");
	
	struct uio auio;
	struct iovec iov;

	iov.iov_base = (void *)data;
	iov.iov_len = size;

	auio.uio_iov = &iov;
	auio.uio_iovcnt = 1;
	auio.uio_segflg = UIO_SYSSPACE;
	auio.uio_rw = UIO_WRITE;
	auio.uio_td = td;
	auio.uio_offset = 0;
	auio.uio_resid = iov.iov_len;

	return sosend(sock, NULL, &auio, 0, NULL, 0, td);
}

void dump_kernel(char *serverIP, int port, struct thread *td)
{
	int	(*socreate) (int dom, struct socket **aso, int type, int proto, struct ucred *cred, struct thread *td);
	int	(*soconnect)(struct socket *so, struct sockaddr *nam, struct thread *td);

	socreate = resolve_function("socreate");
	soconnect = resolve_function("soconnect");

	struct socket *s;

	int r = 0;
	r = socreate(AF_INET, &s, SOCK_STREAM, 0, td->td_proc->p_ucred, td);

	if(r == 0)
	{
		struct sockaddr_in2 server;
		server.sin_len = sizeof(server);
		server.sin_family = AF_INET;
		server.sin_addr.s_addr = HTONL(Ip_to_int(serverIP));
		server.sin_port = HTONS(port);

		r = soconnect(s, (struct sockaddr *)&server, td);
		if(r == 0)
		{
			unsigned char buffer[PKT_SIZE];
			unsigned char *kdata = (void *)0xffffffff80000000;
			int writen = 0;
			
			while(writen < 0x2000000)
			{
				for(int y = 0; y < PKT_SIZE; y++)
					buffer[y] = kdata[writen + y];
				
				socketSendKernel(td, s, &buffer, PKT_SIZE);
				writen += PKT_SIZE;
			}
			
			socketSendKernel(td, s, kdata, 3);
		}
	}
}
