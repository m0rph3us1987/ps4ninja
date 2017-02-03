/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_CPU
#define MRP_CPU 0

struct regs {
	unsigned long long	r_r15;
	unsigned long long	r_r14;
	unsigned long long	r_r13;
	unsigned long long	r_r12;
	unsigned long long	r_r11;
	unsigned long long	r_r10;
	unsigned long long	r_r9;
	unsigned long long	r_r8;
	unsigned long long	r_rdi;
	unsigned long long	r_rsi;
	unsigned long long	r_rbp;
	unsigned long long	r_rbx;
	unsigned long long	r_rdx;
	unsigned long long	r_rcx;
	unsigned long long	r_rax;
	int	r_trapno;
	short	r_fs;
	short	r_gs;
	int	r_err;
	short	r_es;
	short	r_ds;
	unsigned long long	r_rip;
	unsigned long long	r_cs;
	unsigned long long	r_rflags;
	unsigned long long	r_rsp;
	unsigned long long	r_ss;
};

int Nanosleep(const struct timespec *rqtp, void *rmtp);

#define X86_CR0_WP (1 << 16)

unsigned long long GetCR0();
void SetCR0(unsigned long long cr0);

#endif
