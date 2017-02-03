/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#include "../include/minlib.h"


int Strlen(char *a)
{
	int i = 0;
	for (; *a != 0; a++)
		i++;

	return i;
}

void Strrev(char *str)
{
  int i;
  int j;
  unsigned char a;
  unsigned len = Strlen(str);
  for (i = 0, j = len - 1; i < j; i++, j--)
  {
	  a = str[i];
	  str[i] = str[j];
	  str[j] = a;
  }
}

int Strcmp(char *a, char *b)
{
  if(Strlen(a) != Strlen(b))
    return -1;
  
  int i = 0;
  
  while(a[i] != 0)
  {
    if(a[i] != b[i])
      return -1;
    
    i++;
  }
  
  return 0;
}

void Strcpy(char *d, char *s)
{
	int i = 0;

	while (s[i] != 0)
	{
		d[i] = s[i];
		i++;
	}

	d[i] = 0x00;
}

char *Strdup(const char *s)
{
	char *d = Mmap(0,Strlen(s) + 1,PROT_READ|PROT_WRITE,MAP_SHARED|MAP_ANON,-1,0);   // Space for length plus nul
	if (d == NULL) return NULL;          // No memory
	Strcpy(d, s);                        // Copy the characters
	return d;                            // Return the new string
}
