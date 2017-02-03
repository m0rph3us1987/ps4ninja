/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_MEM
#define MRP_MEM 0

#ifndef PROT_READ
	#define	PROT_READ	0x01	/* pages can be read */
#endif
#ifndef PROT_WRITE 
	#define	PROT_WRITE	0x02	/* pages can be written */
#endif
#ifndef PROT_EXEC
	#define	PROT_EXEC	0x04	/* pages can be executed */
#endif

#ifndef MAP_SHARED
	#define	MAP_SHARED	0x0001		/* share changes */
#endif
#ifndef MAP_PRIVATE 
	#define	MAP_PRIVATE	0x0002		/* changes are private */
#endif
#ifndef MAP_FIXED
	#define	MAP_FIXED	 0x0010	/* map addr must be exactly as requested */
#endif
#ifndef MAP_ANON
	#define	MAP_ANON	 0x1000	/* allocated from memory, swap space */
#endif
#ifndef MAP_SELF
	#define	MAP_SELF	0x80000	/* map self */
#endif

int Memcmp(const void *s1, const void *s2, unsigned long n);
void *Mmap(void* addr, unsigned long long len, int prot, int flags, long long fd, void* pos);
int Munmap(void* addr, unsigned long long size);
void Memset(void *s1, int n, unsigned char value);
void Memcpy(void *dst, void *src, unsigned long long cnt);
#endif 
