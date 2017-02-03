#define _WANT_UCRED
#define _XOPEN_SOURCE 700
#define __BSD_VISIBLE 1

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <stdint.h>
#include <inttypes.h>

#include <unistd.h>

#include <sys/syscall.h>
#include <vm/vm.h>

#include <ps4/kernel.h>
#include <sys/user.h>
#include <sce/types/kernel.h>
#include <sce/kernel.h>
#include <fcntl.h>

#include <netinet/tcp.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <sys/uio.h>
#include <ps4/stub_resolve.h>
#include <sys/mman.h>
#include <errno.h>
#include "kmain.h"
#include "ps4ninja.h"


int exit_klog = 0;
int stop_dump = 0;

void KlogThread()
{
	// Prepare socket
	int s = Socket(AF_INET, SOCK_STREAM, 0);

	int client = 0;

	struct sockaddr_in sockadr;
	sockadr.sin_family = AF_INET;
	sockadr.sin_port = HTONS(9081);
	sockadr.sin_addr.s_addr = INADDR_ANY;
	memset(sockadr.sin_zero, 0, sizeof(sockadr.sin_zero));

	int r = 0;
	r = Bind(s, &sockadr, sizeof(sockadr));

	if (r < 0)
	{
		printf("KlogThread -> Bind failed! %d\n", r);
	}

	r = Listen(s, 1000);

	if (r < 0)
	{
		printf("KlogThread -> Listen failed! %d\n", r);
	}

	// Accept clients
	for (;;) 
	{
		client = Accept(s, (struct sockaddr_in *)0, 0);
		if (client > 0)
		{
			int fd, ret;
			char temp[0x2000];

			struct timespec ts;
			ts.tv_nsec = 100000000;
			ts.tv_sec = 0;

			// open the klog
			fd = Open("/dev/klog", O_RDONLY,(int) NULL);
			if (fd == -1)
			{
				stop_dump = 1;
				Exit();
			}

			// loop
			while (1)
			{
				// sleep some
				Nanosleep(&ts, NULL);

				ret = Read(fd, temp, 0xFFF);
				if (ret > 0)
				{
					temp[ret + 1] = 0x00;
					Write(client, temp, Strlen(temp));
				}
			}
		}
	}
}

int main(int argc, char **argv)
{
	printf("Escalating privileges...\n");
	printf("uid: %zu\n", getuid());
	ps4KernelCall(ps4KernelPrivilegeEscalate);
	printf("uid: %zu\n", getuid());
	int64_t ret;

	printf("Patching system ucred...");
	ps4KernelExecute((void *)setsysucred, NULL, &ret, NULL);
	printf("done!\n");

	int MainPID = Getpid();

	Fork();
	if(Getpid() != MainPID)
	{
		KlogThread();
	}
	else
	{
		printf("ps4ninja main pid %d\n", Getpid());
		printf("Starting ps4 ninja server on port %d...\n", 9080);
		ps4ninja_start_server(9080);
	}

	return 0;
}

