/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_SYS
#define MRP_SYS 0

#ifndef CTL_KERN
	#define CTL_KERN 1              /* "high kernel": proc, limits */
#endif

#ifndef KERN_PROC
	#define KERN_PROC 14      		/* struct: process entries */
#endif

#ifndef KERN_PROC_PROC
	#define KERN_PROC_PROC 8       	/* only return procs */
#endif

#ifndef KERN_PROC_VMMAP
	#define KERN_PROC_VMMAP 32		/* VM map entries for process */
#endif

int Sysctl(int *name, unsigned int namelen, void *old, unsigned long long *oldlenp, void *news, unsigned long long newlen);
void EnableUsrASLR(void *kernel_address);
void DisableUsrASLR(void *kernel_address);
#endif
