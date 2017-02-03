/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
 
 #include "../include/minlib.h"
 
int Ptrace_attach(int pid)
{
	int r = Ptrace(PT_ATTACH,pid,0,0);
	printf("Ptrace_attach(): %d\n", r);
	return r;
}
 
int Ptrace_detach(int pid)
{
	int r = Ptrace(PT_DETACH,pid,(int*)SIGCONT,0);
	printf("Ptrace_detach(): %d\n", r);
	return r;
}

int Ptrace_continue(int pid)
{
	int r = Ptrace(PT_CONTINUE,pid,(unsigned long long)1,0);
	printf("Ptrace_continue(): %d\n", r);
	return r;
}

int Ptrace_get_regs(int pid, void *addr)
{
	int r = Ptrace(PT_GETREGS, pid, addr, 0);
	printf("Ptrace_get_regs(): %d\n", r);
	return r;
}

int Ptrace_set_regs(int pid, void *addr)
{
	int r = Ptrace(PT_SETREGS, pid, addr, 0);
	printf("Ptrace_set_regs(): %d\n", r);
	return r;
}

int Ptrace_step(int pid)
{
	int r = Ptrace(PT_STEP, pid, (void *)1, 0);
	printf("Ptrace_step(): %d\n", r);
	return r;
}

int Ptrace_suspend(int pid)
{
	int r = Ptrace(PT_SUSPEND, pid, 0, 0);
	printf("Ptrace_suspend(): %d\n", r);
	return r;
}

int Ptrace_resume(int pid)
{
	int r = Ptrace(PT_RESUME, pid, 1, 0);
	printf("Ptrace_resume(): %d\n", r);
	return r;
}

unsigned long long Ptrace_io(int pid, int op, void *off, void *addr, unsigned long long len)
{
	struct ptrace_io_desc io_desc;
	unsigned long long ret;
	
	io_desc.piod_op = op;
	io_desc.piod_offs = off;
	io_desc.piod_addr = addr;
	io_desc.piod_len = len;
	ret = Ptrace(PT_IO, pid, (unsigned long long)&io_desc, 0);
	printf("Ptrace_io(PT_IO, %d, 0x%llx,0): %d\n", pid, (unsigned long long)&io_desc, ret);
	
	if(ret == 0)
	{
		printf("Ptrace_io(): %d\n", io_desc.piod_len);
		return io_desc.piod_len;
	}
	else
	{
		printf("Ptrace_io(): %d\n", ret);
		return ret;
	}
}
