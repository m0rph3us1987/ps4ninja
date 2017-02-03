/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
 
#include "../include/minlib.h"

unsigned long long GetCR0()
{
	unsigned long long result;
	MinlibSyscall(MINLIB_SYS_GET_CR0, (void *) 0, &result);
	return result;
}

void SetCR0(unsigned long long cr0)
{
	unsigned long long result;
	
	struct sys_minlib_set_cr0_args args;
	args.value = cr0;
	
	MinlibSyscall(MINLIB_SYS_SET_CR0, (void *) &args, &result);
	return;
}