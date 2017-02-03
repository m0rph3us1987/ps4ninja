#ifndef KMainH
#define KMainH

#include <sys/sysent.h>
#include <vm/vm.h>
#include <vm/pmap.h>
#include <vm/vm_map.h>

#define X86_CR0_WP (1 << 16)

static inline __attribute__((always_inline)) uint64_t readCr0(void) {
	uint64_t cr0;
	
	__asm volatile (
		"movq %0, %%cr0"
		: "=r" (cr0)
		: : "memory"
 	);
	
	return cr0;
}

static inline __attribute__((always_inline)) void writeCr0(uint64_t cr0) {
	__asm volatile (
		"movq %%cr0, %0"
		: : "r" (cr0)
		: "memory"
	);
}

int kmain(struct thread *td, void *uap);
int kmain2(struct thread *td, void *uap);
int kmain3(struct thread *td, void *uap);
int kmain4(struct thread *td, void *uap);
int kmain5(struct thread *td, void *uap);
int k_readprocmem(struct  thread *td, void * uap);
int setsysucred(struct  thread *td, void * uap);
int k_writeprocmem(struct thread *td, void * uap);
#endif
