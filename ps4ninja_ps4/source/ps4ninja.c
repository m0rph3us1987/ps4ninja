/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        ps4ninja by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <stdint.h>
#include <inttypes.h>

#include <unistd.h>

#include <netinet/tcp.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <ps4ninja.h>
#include "kmain.h"
#include <ps4/kernel.h>

void ps4ninja_start_server(int port)
{
	int MainPID = Getpid();

	// Spawn a new process for server
	Fork();
	
	// Original process quits here
	if(Getpid() == MainPID)
	{
		DebugPrint("ps4ninja_start_server -> Main proc quitted\n");
		return;
	}
	

	// Prepare socket
	int ServerPID = Getpid();
	int s = Socket(AF_INET, SOCK_STREAM, 0);

	int client = 0;
	
	struct sockaddr_in sockadr;
	sockadr.sin_family = AF_INET;
	sockadr.sin_port = HTONS(port);
	sockadr.sin_addr.s_addr = INADDR_ANY;
	memset(sockadr.sin_zero, 0, sizeof(sockadr.sin_zero));
	
	int r = 0;
	r = Bind( s, &sockadr, sizeof(sockadr));
	
	if (r < 0)
	{
		printf("ps4ninja_start_server -> Bind failed! %d\n", r);
		Exit();
	}

	r = Listen( s, 1000);
	
	if( r < 0 )
	{
		printf("ps4ninja_start_server -> Listen failed! %d\n", r);
		Exit();
	}
	
	// Accept clients
	for(;;){
		printf("ps4ninja_start_server -> Lister proc waiting for connections\n");
		client = Accept(s, (struct sockaddr_in *)0, 0);		
		if(client > 0)
		{
			// Spanw new process per client
			Fork();
			
			if(Getpid() != ServerPID)
				ps4ninja_handle_client(client);
		}
	}
}

void ps4ninja_handle_client(int s)
{
	int64_t ret;
	ps4KernelExecute((void *)setsysucred, NULL, &ret, NULL);

	unsigned char *buffer;
	unsigned char *byte;
	short *traced;


	char lenBuff[4];
	const char *okBuff = "O";
	char *path;
	short *pid;
	
	unsigned long long MemAdr, MemLen;
	unsigned long long *ullPtr;
	unsigned long *len = (unsigned long*)lenBuff;
	
	printf("ps4ninja_handle_client() -> Client connected\n");
	
	while(1)
	{
		printf("ps4ninja_handle_client() -> Waiting for command\n");
		Memset(lenBuff,4,0);
		
		// Read incoming command length
		if(ReadBytes(s, 4, lenBuff) < 0)
			Exit();
		
		printf("ps4ninja_handle_client() -> Command len: %d\n", *len);

		// Send ok to client
		Write(s,(void*)okBuff,1);
	
		printf("ps4ninja_handle_client() -> Sent OK\n");
		
		// Alloc memory for incoming command	
		buffer = (unsigned char *)Mmap(NULL, DEF_BUF_SIZE, PROT_READ | PROT_WRITE, MAP_ANON | MAP_SHARED, -1, 0);
		
		printf("ps4ninja_handle_client() -> Memory allocated at 0x%llx\n",(unsigned long long)buffer);
		
		// Read command
		if(ReadBytes(s,*len,buffer) < 0)
			Exit();

		printf("ps4ninja_handle_client() -> Command received\n");
		
		// Send ok to client
		Write(s, (void*)okBuff,1);
		
		printf("ps4ninja_handle_client() -> Sent OK\n");
		
		// Command evaluation
		short *command = (short*)buffer;		
		printf("ps4ninja_handle_client: Evaluate command-> %d\n",*command);
		
		switch(*command)
		{
			case NINJA_CMD_GET_DENTS:
				path = (char *)buffer;
				path += 2;
				ps4ninja_get_dents(path, s);
				break;
			case NINJA_CMD_KILL_PID:
				pid = (short *)buffer;
				pid++;
				ps4ninja_kill_pid(*pid, s);
				break;
			case NINJA_CMD_SEND_FILE:
			case NINJA_CMD_SEND_DEC_SELF:
				path = (char*)buffer;
				path += 2;
				ps4ninja_send_file(path, s);
				break;
			case NINJA_CMD_GET_PROCS:
				ps4ninja_get_procs(s);
				break;
			case NINJA_CMD_GET_PROC_VMMAP:
				pid = (short *)buffer;
				pid++;				
				ps4ninja_get_proc_vmmap(*pid, s);
				break;
			case NINJA_CMD_ATTACH_PID:
				pid = (short *)buffer;
				pid++;				
				traced = (short*)buffer;
				traced++;
				traced++;				
				ps4ninja_attach_pid(*pid,*traced,s);
				break;
			case NINJA_CMD_DETACH_PID:
				pid = (short *)buffer;
				pid++;				
				ps4ninja_detach_pid(*pid,s);
				break;
			case NINJA_CMD_READ_PROC_MEM:
				pid = (short *)buffer;
				pid++;
				pid++;
				ullPtr = (unsigned long long*)pid;
				pid--;
				MemAdr = *ullPtr;
				ullPtr++;
				MemLen = *ullPtr;
				ps4ninja_read_proc_mem(*pid,(void*)MemAdr,MemLen,s);
				break;
			case NINJA_CMD_CONTINUE:
				pid = (short *)buffer;
				pid++;
				ps4ninja_continue_pid(*pid, s);
				break;
			case NINJA_CMD_READ_REGS:
				pid = (short *)buffer;
				pid++;
				ps4ninja_read_regs(*pid, s);
				break;
			case NINJA_CMD_STEP:
				pid = (short *)buffer;
				pid++;
				ps4ninja_step(*pid, s);
				break;
			case NINJA_CMD_SET_BERAKPOINT:
				pid = (short *)buffer;
				pid++;
				pid++;
				ullPtr = (unsigned long long*)pid;
				pid--;
				MemAdr = *ullPtr;
				ps4ninja_set_breakpoint(*pid,(void*)MemAdr,s);
				break;
			case NINJA_CMD_EXIT_BREAKPOINT:
				pid = (short *)buffer;
				pid++;
				pid++;
				byte = (unsigned char *)pid;
				pid--;
				ps4ninja_exit_breakpoint(*pid, *byte, s);
				break;
			case NINJA_CMD_WRITE_REGS:
				pid = (short *)buffer;
				pid++;
				pid++;
				ullPtr = (unsigned long long*)pid;
				pid--;
				ps4ninja_write_regs(*pid, (struct regs *)ullPtr, s);
				break;
			case NINJA_CMD_RMDIR:
				path = (char *)buffer;
				path += 2;
				ps4ninja_rmdir(path, s);
				break;
			case NINJA_CMD_RMFILE:
				path = (char *)buffer;
				path += 2;
				ps4ninja_rmfile(path, s);
				break;
			case NINJA_CMD_RECEIVE_FILE:
				path = (char *)buffer;
				path += 2;
				ps4ninja_receive_file(path, s);
				break;
			case NINJA_CMD_MKDIR:
				path = (char *)buffer;
				path += 2;
				ps4ninja_mkdir(path, s);
				break;
			case NINJA_CMD_DISABLE_UASLR:
				ps4ninja_disable_userland_aslr(s);
				break;
			case NINJA_CMD_ENABLE_UASLR:
				ps4ninja_enable_userland_aslr(s);
				break;
			case NINJA_CMD_DISABLE_RWX:
				ps4ninja_disable_rwx_mapping(s);
				break;
			case NINJA_CMD_ENABLE_RWX:
				ps4ninja_enable_rwx_mapping(s);
				break;
			case NINJA_CMD_APPLY_KPF:
				path = (char *)buffer;
				path += 2;
				ps4ninja_apply_kpf((u64)path, s);
				break;
			case NINJA_CMD_READ_KMEM:
				pid = (short *)buffer;
				pid++;
				pid++;
				ullPtr = (unsigned long long*)pid;
				pid--;
				MemAdr = *ullPtr;
				ullPtr++;
				MemLen = *ullPtr;
				ps4ninja_read_kmem(*pid, (void*)MemAdr, MemLen, s);
				break;
			case NINJA_CMD_WRITE_KMEM:
				pid = (short *)buffer;
				pid++;
				ullPtr = (unsigned long long *)pid; 
				MemAdr = *ullPtr;
				ullPtr++;
				MemLen = *ullPtr;
				ullPtr++;
				ps4ninja_write_kmem(0, (void*)ullPtr, (void*)MemAdr, MemLen, s);
				break;
			default:
				Munmap(buffer, DEF_BUF_SIZE);
				Exit();
				break;
		}
	
		// Free allocated command space
		printf("ps4ninja_handle_client() -> Clearing command buffer!\n");
		Munmap(buffer, DEF_BUF_SIZE);
		printf("ps4ninja_handle_client() -> Memory at 0x%llx unmapped!\n",(unsigned long long)buffer);
	}
}

void ps4ninja_get_dents(char *path, int s)
{
	printf("ps4ninja_get_dents(%s)\n", path);

	char lenBuff[4];
	unsigned long *len = (unsigned long*)lenBuff;
	char okBuffClient[1];

	int fd = Open(path, O_RDONLY, O_DIRECTORY );
			
	unsigned char *buffer2 = (unsigned char *)Mmap(NULL, DEF_BUF_SIZE, PROT_READ | PROT_WRITE, MAP_ANON | MAP_SHARED, -1, 0);

	int writtenBytes = 0;

	if( Getdents(fd, (char*)buffer2, DEF_BUF_SIZE ) != -1)
	{
		printf("ps4ninja_get_dents()-> Got dents\n");
		*len = DEF_BUF_SIZE;

		Write(s,(void *)lenBuff,(int)4);
		printf("ps4ninja_get_dents()-> Written 4 bytes answer length\n");

		printf("ps4ninja_get_dents()-> Waiting for client ok\n");
		if (ReadBytes(s, 1, okBuffClient) < 0)
		{
			printf("ps4ninja_get_dents()-> Read client ok failed! Exit()!\n");
			Exit();
		}
		else
		{
			if(okBuffClient[0] == 0x4f)
			{
				printf("ps4ninja_get_dents()-> Received client ok\n");
				unsigned char *tmpB = buffer2;
				while(writtenBytes < *len)
				{
					writtenBytes += Write(s, tmpB, *len - writtenBytes);
					tmpB += writtenBytes;
				}
				printf("ps4ninja_get_dents()-> Dents sent to clients\n");
			} else {
				printf("ps4ninja_get_dents()-> Client sent wrong answer!\n");
				Exit();
			}
		}

		Close(fd);
		printf("ps4ninja_get_dents()-> Clearing buffer!\n");
		Munmap(buffer2, DEF_BUF_SIZE);
	}
	else
	{
		printf("ps4ninja_get_dents()-> Failed to get dents\n");
		Close(fd);
		*len = 0;
		Write(s,(void *)lenBuff,(int)4);
		while(Recv(s,okBuffClient,*len,0,0,0) != 4);
	}

	printf("ps4ninja_get_dents()-> Finish!\n");
}

void ps4ninja_kill_pid(short pid, int socket)
{
	char lenBuff[4];
	unsigned long *len = (unsigned long*)lenBuff;
	
	Kill(pid, SIG_KILL);
			
	*len = 0;
	Write(socket,(void *)lenBuff,(int)4);
}

void ps4ninja_get_procs(int s)
{
	char ClientAnswer[1];
	
	unsigned long long len;
	int mib[3];

	mib[0] = CTL_KERN;
	mib[1] = KERN_PROC;
	mib[2] = KERN_PROC_PROC;
	
	len = 0;
	if (Sysctl(mib, 3, NULL, &len, NULL, 0) < 0)
	{
		len = 0;
		Write(s, &len, 8);
		return;
	}
	
	unsigned char *procs = (unsigned char *)Mmap(NULL, len,  PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANON, -1 , 0);
	Sysctl(mib, 3, procs, &len, NULL, 0);
	
	// Sending data size to client
	Write(s, &len, 8);
	
	// Reading answer from client
	Read(s, ClientAnswer, 1);
	
	if(ClientAnswer[0] == 'O')
	{
		Write(s, procs, len);
	}
  
	Munmap(procs, len);
	
	return;
}

void ps4ninja_get_proc_vmmap(int pid, int s)
{
	char ClientAnswer[1];
	
	unsigned long long len;
	int mib[4];

	mib[0] = CTL_KERN;
	mib[1] = KERN_PROC;
	mib[2] = KERN_PROC_VMMAP;
	mib[3] = pid;
	
	len = 0;
	if (Sysctl(mib, 4, NULL, &len, NULL, 0) < 0)
	{
		len = 0;
		Write(s, &len, 8);
		return;
	}
	
	len = len * 4 / 3;
	
	unsigned char *vmaps = (unsigned char *)Mmap(NULL, len,  PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANON, -1 , 0);
	Sysctl(mib, 4, vmaps, &len, NULL, 0);
	
	// Sending data size to client
	Write(s, &len, 8);
	
	// Reading answer from client
	Read(s, ClientAnswer, 1);
	
	if(ClientAnswer[0] == 'O')
		Write(s, vmaps, len);
  
	Munmap(vmaps, len);
	
	return;
}

void ps4ninja_send_file(char *path, int s)
{
	printf("ps4ninja_send_file(%s)\n",path);

	int CommandPID = Getpid();
	
	unsigned char clientPortBuff[4];
	unsigned char clientIPBuff[4];
	unsigned char fileLenBuff[8];
	
	unsigned long long *fileLen = (unsigned long long*)fileLenBuff;
	unsigned long *clientPort = (unsigned long*)clientPortBuff;
	unsigned long *clientIP = (unsigned long*)clientIPBuff;

	int fd = Open(path, O_RDONLY, 0 );
	printf("ps4ninja_send_file(1) -> open returned: %d\n", fd);
	printf("ps4ninja_send_file(1) -> reading file size...\n");
	*fileLen = Lseek(fd, 0, SEEK_END);
	Close(fd);
	printf("ps4ninja_send_file(1) -> fileLen: %llu\n", *fileLen);
	
	printf("ps4ninja_send_file(1) -> Sending file size to client");
	Write(s,(void *)fileLenBuff,(int)8);

	if (*fileLen == 0)
	{
		printf("ps4ninja_send_file(1) -> Filesize is 0, so exit...");
		return;
	}
	
	printf("ps4ninja_send_file(1) -> Reading client port and IP\n");
	if (ReadBytes(s, 4, clientPort) < 0)
		Exit();
	
	ReadBytes(s,4,clientIP);
	
	printf("ps4ninja_send_file(1) -> Got client port and IP\n");
		
	Fork();
	
	if(Getpid() != CommandPID)
	{
		int d = 0;
		d = Open(path, O_RDONLY, 0);
		printf("ps4ninja_send_file(2) -> open returned: %d\n", d);
		Lseek(d, 0, SEEK_SET);

		int tmpPid = Getpid();
		printf("ps4ninja_send_file(2) -> reverse connecting to client\n");

		int dataSock = Connect2(HTONL(*clientIP), (int)*clientPort);

		printf("ps4ninja_send_file(2) -> sending data PID\n");
		Write(dataSock, &tmpPid, 2);

		int writtenBytes = 0;
		unsigned long long sentBytes = 0;
		unsigned char tmpReadBuff[DEF_BUF_SIZE];
		unsigned long readBytes = 0;

		printf("ps4ninja_send_file(2) -> sending data...\n");
		while (sentBytes < *fileLen)
		{
			writtenBytes = 0;
			readBytes = Read(d, tmpReadBuff, DEF_BUF_SIZE);

			if (readBytes > 0)
				writtenBytes = Write(dataSock, tmpReadBuff, readBytes);
			else {
				Close(d);
				Exit();
			}

			sentBytes += writtenBytes;
		}

		Close(d);
		Exit();
	}
}

void ps4ninja_attach_pid(short pid, short traced, int s)
{
	printf("ps4ninja_attach(%d)\n",pid);
	
	int stat = 0;
	
	int ret = Ptrace_attach(pid);
	printf("ps4ninja_attach() -> Ptrace_attach returned %d\n",ret);
	
	if(traced != 1)
		Wait4(pid,&stat,WUNTRACED,0);
	else
		Wait4(pid,&stat,WCONTINUED,0);
			
	
	ps4ninja_client_answer32(ret, s);
}

void ps4ninja_detach_pid(short pid, int s)
{
	printf("ps4ninja_detach(%d)\n",pid);
	
	int ret = Ptrace_detach(pid);
	printf("ps4ninja_detach() -> Ptrace_detach returned %d\n",ret);
	
	ps4ninja_client_answer32(0, s);
}

void ps4ninja_read_proc_mem(short pid, void *addr, unsigned long long len, int socket)
{
	char ClientAnswer[1];
	unsigned long long readSize = len;
	
	// Alloc mem and read data with ptrace
	unsigned char *kdata = (unsigned char *)Mmap(NULL, len, PROT_READ | PROT_WRITE, MAP_ANON | MAP_SHARED, -1, 0);
	Ptrace_io(pid, PIOD_READ_I, addr, kdata, readSize);
	
	// Send data size to client
	Write(socket, &readSize, 8);
	
	// Reading answer from client
	Read(socket, ClientAnswer, 1);
	
	// Send data to client
	unsigned long long sentBytes = 0;
	
	while(sentBytes < readSize)
		sentBytes += Write(socket, kdata, readSize);
	
	Munmap(kdata, readSize);
}

void ps4ninja_write_proc_mem(short pid,void *srcAddr, void *addr, unsigned long long len, int socket)
{
	unsigned long long readSize = 0;
	
	if(len < 4096)
		readSize = len;
	else
		readSize = 4096;
	
	Ptrace_io(pid, PIOD_WRITE_D, addr, srcAddr, readSize);
	
	readSize = 0;
	// Send data size to client
	Write(socket, &readSize, 8);
}

void ps4ninja_continue_pid(short pid, int s)
{
	char ClientAnswer[1];

	char lenBuff[8];
	u64 *len = (u64*)lenBuff;

	printf("ps4ninja_continue_pid()-> Calling Ptrace_continue();\n");

	Ptrace_continue(pid);
	
	int stat = 0;
	printf("ps4ninja_continue_pid()-> Waiting\n");
	Wait4(pid,&stat,WUNTRACED,0);
	
	// Send answer size to client
	*len = 8;
	printf("ps4ninja_continue_pid()-> Writing answer len\n");
	Write(s, (void *)lenBuff, (int)8);
	*len = 0;

	printf("ps4ninja_continue_pid()-> Reading client answer\n");
	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
	{
		printf("ps4ninja_continue_pid()-> returning 0x%llx\n", *len);
		Write(s, (void *)lenBuff, 8);
	}
	else
	{
		printf("ps4ninja_continue_pid()-> Client answer not ok!\n");
	}

	printf("ps4ninja_continue_pid()-> Exit function\n");
}

void ps4ninja_read_regs(short pid, int s)
{
	struct regs PS4Regs;
	
	char ClientAnswer[1];

	char lenBuff[8];
	unsigned long long *len = (unsigned long long*)lenBuff;

	Ptrace_get_regs(pid, &PS4Regs);

	// Send answer size to client
	*len = sizeof(PS4Regs);
	Write(s, (void *)lenBuff, (int)8);

	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
	{
		Write(s, (void *)&PS4Regs, sizeof(PS4Regs));
	}
}

void ps4ninja_step(short pid, int s)
{
	Ptrace_step(pid);

	int stat = 0;
	Wait4(pid,&stat,WUNTRACED,0);
	
	ps4ninja_client_answer64(0, s);
}

void ps4ninja_suspend(short pid, int s)
{
	Ptrace_suspend(pid);
	ps4ninja_client_answer64(0, s);
}

void ps4ninja_resume(short pid, int s)
{
	Ptrace_resume(pid);

	printf("ps4ninja_resume()-> returning 0x%llx\n", 0);

	ps4ninja_client_answer64(0, s);
}

void ps4ninja_set_breakpoint(short pid, void *addr, int s)
{
	char ClientAnswer[1];

	char lenBuff[8];
	unsigned long long *len = (unsigned long long*)lenBuff;
	
	unsigned char OriginalByte = 0xFF;
	unsigned char Int13 = 0xCC;
	
	// Read Original byte
	printf("ps4ninja_set_breakpoint() -> OriginalByte: %x\n",OriginalByte);
	printf("ps4ninja_set_breakpoint() -> Calling Ptrace_io(PT_IO, %d, 0x%llx, 0x%llx, %llu)\n", pid, addr, &OriginalByte, 1);
	Ptrace_io(pid, PIOD_READ_D, addr, &OriginalByte, 1);
	
	printf("ps4ninja_set_breakpoint() -> OriginalByteNew: %x\n",OriginalByte);
	// Write int 3h to memory
	Ptrace_io(pid, PIOD_WRITE_D, addr, &Int13, 1);
	
	// Send answer size to client
	*len = 1;
	Write(s, (void *)lenBuff, (int)8);
	printf("ps4ninja_set_breakpoint() -> Sent len to client: %llu\n",*len);
	
	// Reading answer from client
	Read(s, ClientAnswer, 1);
	
	if (ClientAnswer[0] == 'O')
		Write(s, (void *)&OriginalByte, 1);
}

void ps4ninja_exit_breakpoint(short pid, unsigned char originalOpcode, int s)
{
	char ClientAnswer[1];

	char lenBuff[8];
	unsigned long long *len = (unsigned long long*)lenBuff;

	// Read registers and set RIP = RIP - 1
	struct regs PS4Regs;
	Ptrace_get_regs(pid, &PS4Regs);
	PS4Regs.r_rip--;
	Ptrace_set_regs(pid, &PS4Regs);

	// Write original opcode
	unsigned long long addr = PS4Regs.r_rip;
	Ptrace_io(pid, PIOD_WRITE_D, (void*)addr, &originalOpcode, 1);

	// Send answer size to client
	*len = 1;
	Write(s, (void *)lenBuff, (int)8);

	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
		Write(s, (void *)&originalOpcode, 1);
}

void ps4ninja_write_regs(short pid, struct regs *ps4Regs, int s)
{
	char ClientAnswer[1];

	char lenBuff[8];
	unsigned long long *len = (unsigned long long*)lenBuff;

	Ptrace_set_regs(pid, ps4Regs);
	Ptrace_get_regs(pid, ps4Regs);

	// Send answer size to client
	*len = sizeof(ps4Regs);
	Write(s, (void *)lenBuff, (int)8);

	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
	{
		Write(s, (void *)&ps4Regs, sizeof(ps4Regs));
	}
}

void ps4ninja_rmdir(char *path, int s)
{
	unsigned long long ret = Rmdir(path);

	ps4ninja_client_answer64(ret, s);
}

void ps4ninja_rmfile(char *path, int s)
{
	unsigned long long ret = Unlink(path);

	ps4ninja_client_answer64(ret, s);
}

void ps4ninja_receive_file(char *params, int s)
{
	int CommandPID = Getpid();

	unsigned long long *ullptr = (unsigned long long *)params;
	u32  *uiptr;
	unsigned short *usptr;

	

	unsigned long long Filesize = *ullptr;
	
	ullptr++;
	uiptr = (u32*)ullptr;

	u32  ClientPort = *uiptr;
	uiptr++;
	u32  ClientIP = *uiptr;
	uiptr++;

	usptr = (unsigned short*)uiptr;
	unsigned short FilenameSize = *usptr;
	usptr++;
	char *Filename = (char*)usptr;

	printf("ps4ninja_receive_file(1)-> Receiving %s - IP %llx - PORT %d - Filesize %llu - FilenameSize %d\n", Filename, ClientIP, ClientPort, Filesize, FilenameSize);

	
	Fork();	

	if (Getpid() == CommandPID)
	{
		ps4ninja_client_answer64(0, s);
		return;
	}

	// Try to create local file
	Unlink(Filename);
	int fd = Open(Filename, O_CREAT | O_WRONLY, 0777);

	printf("ps4ninja_receive_file(2)-> Create file %s returned %d \n", Filename, fd);

	// Connect to pc
	int tmpPid = Getpid();
	printf("ps4ninja_receive_file(2)-> reverse connecting to client.\n");

	int dataSock = Connect2(HTONL(ClientIP), (int)ClientPort);
	printf("ps4ninja_receive_file(2)-> Connect2 returned %d\n",dataSock);

	printf("ps4ninja_receive_file(2)-> sending data PID\n");
	Write(dataSock, &tmpPid, 2);

	unsigned long long ReceivedBytes = 0;

	unsigned char *fileContent = Mmap(0, 4096, PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANON, -1, 0);
	printf("ps4ninja_receive_file(2)-> File space allocated at 0x%llx\n", fileContent);

	int readBytes = 0;

	printf("ps4ninja_receive_file(2)-> Reading from socket\n");
	while (ReceivedBytes != Filesize)
	{
		if(Filesize - ReceivedBytes < 4096)
			readBytes = Read(dataSock, fileContent, Filesize - ReceivedBytes);
		else
			readBytes = Read(dataSock, fileContent, 4096);

		Write(fd, fileContent, readBytes);
		ReceivedBytes += readBytes;
	}
		

	printf("ps4ninja_receive_file(2)-> Received %d bytes\n", ReceivedBytes);

	printf("ps4ninja_receive_file(2)-> Freeing memory and closing handles\n");
	Munmap(fileContent, 4096);
	Close(dataSock);
	Close(fd);

	printf("ps4ninja_receive_file(2)-> Exit process\n");
	Exit();
}

void ps4ninja_mkdir(char *path, int s)
{
	unsigned long long ret = Mkdir(path, 755);
	printf("ps4ninja_mkdir() -> Mkdir(%s) returned %d\n", path, ret);

	ps4ninja_client_answer64(ret, s);
}

void ps4ninja_client_answer64(u64 value, int s)
{
	char ClientAnswer[1];

	char lenBuff[8];
	unsigned long long *len = (unsigned long long*)lenBuff;

	// Send answer size to client
	*len = 8;
	Write(s, (void *)lenBuff, (int)8);

	*len = value;

	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
		Write(s, (void *)lenBuff, 8);
}

void ps4ninja_client_answer32(u32 value, int s)
{
	char ClientAnswer[1];

	char lenBuff[4];
	u32 *len = (u32*)lenBuff;

	// Send answer size to client
	*len = 4;
	Write(s, (void *)lenBuff, (int)4);

	*len = value;

	// Reading answer from client
	Read(s, ClientAnswer, 1);

	if (ClientAnswer[0] == 'O')
		Write(s, (void *)lenBuff, 4);
}

void ps4ninja_disable_userland_aslr(int s)
{
	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_disable_userland_aslr, NULL, &ret, NULL);

	ps4ninja_client_answer64(ret, s);
}

void ps4ninja_enable_userland_aslr(int s)
{
	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_enable_userland_aslr, NULL, &ret, NULL);
	
	ps4ninja_client_answer64(ret, s);
}

void ps4ninja_enable_rwx_mapping(int s)
{
	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_enable_rwx_mapping, NULL, &ret, NULL);
	
	ps4ninja_client_answer64(0, s);
}

void ps4ninja_disable_rwx_mapping(int s)
{
	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_disable_rwx_mapping, NULL, &ret, NULL);

	ps4ninja_client_answer64(0, s);
}

void ps4ninja_apply_kpf(u64 addr, int s)
{
	struct ps4ninja_kpf_uap uap;
	uap.kpf = addr;

	ps4ninja_kernel_apply_kpf(NULL, &uap);

	ps4ninja_client_answer64(0, s);
}

int ps4ninja_kernel_apply_kpf(void *td, void * uap)
{
	struct ps4ninja_kpf_uap *kpf = (struct ps4ninja_kpf_uap *)uap;

	printf("ps4ninja_kernel_apply_kpf() -> Trying to apply kpf\n");

	u64 *kaddr = (u64 *)kpf->kpf;
	u16 *size = (u16*)kaddr+8;

	while (*kaddr != 2801)
	{
		unsigned char *dst = (unsigned char *)*kaddr;
		unsigned char *src = (unsigned char *)size + 2;
		
		printf("ps4ninja_kernel_apply_kpf() -> Applying %d bytes to 0x%llx\n", *size, dst);

		for (int i = 0; i < *size; i++)
			dst[i] = src[i];

		kaddr = (u64 *)src + *size;
		size = (u16 *)kaddr + 8;
	}

	return 0;
}

void ps4ninja_read_kmem(short pid, void *addr, unsigned long long len, int socket)
{
	printf("ps4ninja_read_kmem() -> Read %d bytes from 0x%llx\n",len,addr);

	char ClientAnswer[1];
	unsigned long long readSize = len;

	// Alloc mem and read data from kernel
	unsigned char *kdata = (unsigned char *)Mmap(NULL, len, PROT_READ | PROT_WRITE, MAP_ANON | MAP_SHARED, -1, 0);
	printf("ps4ninja_read_kmem() -> output buffer allocated at 0x%llx\n", kdata);

	// Read kernel memory
	struct ps4ninja_read_kmem_uap uap;
	uap.kernel_addr = (u64)addr;
	uap.user_addr = (u64)kdata;
	uap.len = len;

	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_read_kmem, &uap, &ret, NULL);

	// Send data size to client
	Write(socket, &readSize, 8);

	// Reading answer from client
	Read(socket, ClientAnswer, 1);

	// Send data to client
	unsigned long long sentBytes = 0;

	while (sentBytes < readSize)
		sentBytes += Write(socket, kdata, readSize);

	Munmap(kdata, readSize);
}

void ps4ninja_write_kmem(short pid, void *buff, void *kaddr, unsigned long long len, int socket)
{
	printf("ps4ninja_write_kmem() -> Write %d bytes to 0x%llx\n", len, kaddr);

	unsigned long long readSize = len;

	// Prepare write kernel memory uap
	struct ps4ninja_write_kmem_uap uap;
	uap.kernel_addr = (u64)kaddr;
	uap.user_addr = (u64)buff;
	uap.len = len;

	int64_t ret;
	ps4KernelExecute((void *)ps4ninja_kernel_write_kmem, &uap, &ret, NULL);

	ps4ninja_client_answer64(ret, socket);
}
