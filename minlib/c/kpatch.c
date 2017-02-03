/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#include "../include/minlib.h"

void EnableRWXMapping(int fw)
{
	char patch[] = { 0x07 };

	switch (fw)
	{
	case FW_170:
		PatchKernel((void*)0xFFFFFFFF825A9C5C, patch, 1);
		PatchKernel((void*)0xFFFFFFFF825A9C88, patch, 1);
		break;
	case FW_176:
		PatchKernel((void*)0xFFFFFFFF825AB7BC, patch, 1);
		PatchKernel((void*)0xFFFFFFFF825AB7E8, patch, 1);
		break;
	default:
		break;
	}
}

void DisableRWXMapping(int fw)
{
	char patch[] = { 0x03 };

	switch (fw)
	{
	case FW_170:
		PatchKernel((void*)0xFFFFFFFF825A9C5C, patch, 1);
		PatchKernel((void*)0xFFFFFFFF825A9C88, patch, 1);
		break;
	case FW_176:
		PatchKernel((void*)0xFFFFFFFF825AB7BC, patch, 1);
		PatchKernel((void*)0xFFFFFFFF825AB7E8, patch, 1);
		break;
	default:
		break;
	}
}

void DisableUsrASLR(void *kernel_address)
{
	/*
	char patch[] = { 0x31, 0xC0, 0xC3 };		// xor rax,rax ; ret
	PatchKernel(kernel_address, patch, 3);
	*/
}

void EnableUsrASLR(void *kernel_address)
{
	/*
	unsigned char patch[] = { 0x55, 0x48, 0x89 };		// original bytes
	PatchKernel(kernel_address, patch, 3);
	*/
}

void PatchKernel(void *addr, void *patch, unsigned long long len)
{
	// Disable write protection
	unsigned long long cr0 = GetCR0();
	SetCR0(cr0 & ~X86_CR0_WP);

	// patch memory region
	unsigned long long result;

	struct sys_minlib_memcpy_args args;
	args.dst = addr;
	args.src = patch;
	args.len = len;
	MinlibSyscall(MINLIB_SYS_MEMCPY, (void*)&args, &result);

	// restore write protection
	SetCR0(cr0);
}