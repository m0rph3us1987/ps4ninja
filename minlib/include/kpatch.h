/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_KPATCH
#define MRP_KPATCH 0

#define FW_170	170
#define FW_176	176

void EnableRWXMapping(int fw);
void DisableRWXMapping(int fw);
void EnableUsrASLR(void *kernel_address);
void DisableUsrASLR(void *kernel_address);
void PatchKernel(void *addr, void *patch, unsigned long long len);

#endif
