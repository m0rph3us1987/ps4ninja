#undef _SYS_CDEFS_H_
#undef _SYS_TYPES_H_
#undef _SYS_PARAM_H_
#undef _SYS_MALLOC_H_

#define _XOPEN_SOURCE 700
#define __BSD_VISIBLE 1
#define _KERNEL
#define _WANT_UCRED
#include <sys/cdefs.h>
#include <sys/types.h>
#include <sys/param.h>
#include <sys/kernel.h>
#include <sys/systm.h>
#include <sys/malloc.h>
#include <sys/proc.h>
#include <sys/user.h>
#include <sys/uio.h>
#include <sys/ptrace.h>

#undef offsetof
#include <kernel.h>
#include <ps4/kernel.h>

#include "kmain.h"
int (*printfkernel)(const char *fmt, ...) = (void *)0xFFFFFFFF8246E340;
int (*Copyout)(const void *kaddr, void *uaddr, size_t len) = (void*)0xFFFFFFFF82613C40;
int(*Copyin)(const void *udaddr, void *kaddr, size_t len) = (void*)0xFFFFFFFF82613CC0;
typedef int64_t (*kernel_memset)(void* ptr, int value, size_t num);

struct ps4ninja_read_kmem_uap
{
	unsigned long long kernel_addr;
	unsigned long long user_addr;
	unsigned long long len;
};

struct ps4ninja_write_kmem_uap
{
	unsigned long long kernel_addr;
	unsigned long long user_addr;
	unsigned long long len;
};

kernel_memset Kmemset =  ((int64_t (*)(void * ptr, int value, size_t num))0xFFFFFFFF8261EB30);


int setsysucred(struct thread *td, void * uap)
{
	ps4KernelProtectionWriteDisable();
	
	
	// Allow self decryption		
	// sceSblAuthMgrIsLoadable		
	*(uint8_t *)(0xFFFFFFFF827C67A0) = 0x31;
	*(uint8_t *)(0xFFFFFFFF827C67A1) = 0xC0;
	*(uint8_t *)(0xFFFFFFFF827C67A2) = 0xC3;
	// allow mapping selfs - place 2
	*(uint8_t *)(0xFFFFFFFF825F5200) = 0xB8;
	*(uint8_t *)(0xFFFFFFFF825F5201) = 0x01;
	*(uint8_t *)(0xFFFFFFFF825F5202) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5203) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5204) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5205) = 0xC3;
	// allow mapping selfs - place 3
	*(uint8_t *)(0xFFFFFFFF825F5210) = 0xB8;
	*(uint8_t *)(0xFFFFFFFF825F5211) = 0x01;
	*(uint8_t *)(0xFFFFFFFF825F5212) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5213) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5214) = 0x00;
	*(uint8_t *)(0xFFFFFFFF825F5215) = 0xC3;
	
	ps4KernelProtectionWriteEnable();

	
	void *td_ucred = *(void **)(((char *)td) + 304); // p_ucred == td_ucred
	
	// sceSblACMgrIsSystemUcred
	uint64_t *sonyCred = (uint64_t *)(((char *)td_ucred) + 96);
	*sonyCred = 0xffffffffffffffff;
	
	// sceSblACMgrGetDeviceAccessType
	uint64_t *sceProcType = (uint64_t *)(((char *)td_ucred) + 88);
	*sceProcType = 0x3801000000000013; // Max access
	
	// sceSblACMgrHasSceProcessCapability
	uint64_t *sceProcCap = (uint64_t *)(((char *)td_ucred) + 104);
	*sceProcCap = 0xffffffffffffffff; // Sce Process

	return 0;
}

void ps4ninja_kernel_disable_userland_aslr()
{
	// Disable write protection
	ps4KernelProtectionWriteDisable();

	*(uint8_t *)0xFFFFFFFF82404630 = 0x31;
	*(uint8_t *)0xFFFFFFFF82404631 = 0xC0;
	*(uint8_t *)0xFFFFFFFF82404632 = 0xC3;

	// Restore write protection
	ps4KernelProtectionWriteEnable();
}

void ps4ninja_kernel_enable_userland_aslr()
{
	// Disable write protection
	ps4KernelProtectionWriteDisable();

	*(uint8_t *)0xFFFFFFFF82404630 = 0x55;
	*(uint8_t *)0xFFFFFFFF82404631 = 0x48;
	*(uint8_t *)0xFFFFFFFF82404632 = 0x89;

	// Restore write protection
	ps4KernelProtectionWriteEnable();
}

void ps4ninja_kernel_disable_rwx_mapping()
{
	// Disable write protection
	ps4KernelProtectionWriteDisable();

	*(uint8_t *)0xFFFFFFFF825AB7BC = 0x03;
	*(uint8_t *)0xFFFFFFFF825AB7E8 = 0x03;

	// Restore write protection
	ps4KernelProtectionWriteEnable();
}

void ps4ninja_kernel_enable_rwx_mapping()
{
	//getEAPPartitionKey();

	// Disable write protection
	ps4KernelProtectionWriteDisable();

	*(uint8_t *)0xFFFFFFFF825AB7BC = 0x07;
	*(uint8_t *)0xFFFFFFFF825AB7E8 = 0x07;

	// Restore write protection
	ps4KernelProtectionWriteEnable();
}

void ps4ninja_kernel_read_kmem(struct thread *td, struct ps4ninja_read_kmem_uap *uap)
{
	printf("ps4ninja_kernel_read_kmem() -> transferring %llu bytes from 0x%llx to 0x%llx\n", uap->len, uap->kernel_addr, uap->user_addr);
	Copyout((void*)uap->kernel_addr, (void*)uap->user_addr, uap->len);
}

void ps4ninja_kernel_write_kmem(struct thread *td, struct ps4ninja_write_kmem_uap *uap)
{
	printf("ps4ninja_kernel_write_kmem() -> transferring %llu bytes from 0x%llx to 0x%llx\n", uap->len, uap->user_addr, uap->kernel_addr);
	unsigned char buff[4096];
	Copyin((void*)uap->user_addr, (void*)buff, uap->len);

	unsigned char *kmem = (unsigned char*)uap->kernel_addr;

	// Disable write protection
	ps4KernelProtectionWriteDisable();

	for (int i = 0; i < uap->len; i++)
		kmem[i] = buff[i];

	// Restore write protection
	ps4KernelProtectionWriteEnable();
}


