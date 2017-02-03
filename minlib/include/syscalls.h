/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
 
typedef unsigned long long u64;

#define MINLIB_SYS_CHECK					0x00		// Check if syscall works
#define MINLIB_SYS_MEMCPY					0x01		// Memcpy
#define MINLIB_SYS_GET_CR0					0x02		// Gets value of cr0 register
#define MINLIB_SYS_SET_CR0					0x03		// Set value of cr0 register

struct sys_minlib_memcpy_args {
	unsigned char *dst;
	unsigned char *src;
	unsigned long long len;
};

struct sys_check_args {
	unsigned long long value;
};

struct sys_minlib_set_cr0_args {
	unsigned long long value;
};

void kernel_syscall_install(int num, void *call, int narg);
void Install_Kernel_Addon(unsigned long long usrcodeAddr);
void MinlibSyscall(int syscall_no, void *params, unsigned long long *result);
