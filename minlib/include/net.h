/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#ifndef MRP_NET
#define MRP_NET 0

#include <netinet/in.h>

#define		AF_INET		2	/* internetwork: UDP, TCP, etc. */
#define		AF_INET6	28	/* IPv6 */

#ifndef INADDR_ANY
#define	INADDR_ANY		(unsigned long)0x00000000
#endif

#define		SOCK_STREAM	1	/* stream socket */
#define		SOCK_DGRAM	2	/* datagram socket */
#define		SOCK_RAW	3	/* raw-protocol interface */

#define HTONS(n) (((((unsigned short)(n) & 0xFF)) << 8) | (((unsigned short)(n) & 0xFF00) >> 8))
#define HTONL(n) (((((unsigned long)(n) & 0xFF)) << 24) | ((((unsigned long)(n) & 0xFF00)) << 8) | ((((unsigned long)(n) & 0xFF0000)) >> 8) | ((((unsigned long)(n) & 0xFF000000)) >> 24))

struct sockaddr_in2 {
	unsigned char    sin_len;
    short            sin_family;   // e.g. AF_INET
    unsigned short   sin_port;     // e.g. htons(3490)
    struct in_addr   sin_addr;     // see struct in_addr, below
    char             sin_zero[8];  // zero this if you want to
};

unsigned int Ip_to_int (const char * ip); 
int Socket(int domain, int type, int protocol);
int Connect(char *ip, int port);
int Connect2(unsigned long ip, int port);
int connect_sys(int sockfd, const struct sockaddr_in *addr, int addrlen);
int Accept(int s, const struct sockaddr_in *addr, int addrlen);
int Bind(int s, const struct sockaddr_in *name, int namelen);
int Listen(int s, int backlog);
int Recv(int s, void *buf, int len, int flags, int dummy, int dummy2);
int ReadBytes(int socket, unsigned long x, void* buffer);
#endif
