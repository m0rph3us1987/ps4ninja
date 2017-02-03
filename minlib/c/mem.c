 /* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#include "../include/minlib.h"

int Memcmp(const void *s1, const void *s2, unsigned long n)
{
  if (n != 0) {
    const unsigned char *p1 = s1, *p2 = s2;

    do {
	    if (*p1++ != *p2++)
		    return (*--p1 - *--p2);
    } while (--n != 0);
  }
  return (0);
}

void Memset(void *s1, int n, unsigned char value)
{
	unsigned char *c = s1;
	
	for(int i = 0; i < n; i++)
	{
		c[i] = value;
		i++;
	}
}

void *Realloc(void *original, int size)
{
	unsigned char *memNew = Mmap(0, size, PROT_READ | PROT_WRITE, MAP_ANON | MAP_SHARED, -1, 0);
	Memcpy(memNew, original, size);
	Munmap(original, size);
	return memNew;
}


void Memcpy(void *dst, void *src, unsigned long long len)
{
	printf("MINLIB: Memcpy(0x%llx,0x%llx,%d)\n", dst, src, len);
	unsigned char *s1 = src;
	unsigned char *s2 = dst;
	for (int i = 0; i < len; i++)
		s2[i] = s1[i];
}
