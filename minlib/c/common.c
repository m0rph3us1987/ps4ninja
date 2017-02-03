/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#include "../include/minlib.h"

int Itoa(int num, char *str, int len, int base)
{
  int sum = num;
  int i = 0;
  int digit;
  if (len == 0)
	  return -1;
  do
  {
    digit = sum % base;
    if (digit < 0xA)
      str[i++] = '0' + digit;
    else
      str[i++] = 'A' + digit - 0xA;
    sum /= base;
  }while (sum && (i < (len - 1)));
  if (i == (len - 1) && sum)
    return -1;
  str[i] = '\0';
  Strrev(str);
  return 0;
} 

int Atoi(char *pStr)
{
  int n; char g = 0;
  if (*pStr == '-') { g = 1; pStr++; }
  for(n=0;*pStr >= '0' && *pStr <= '9';pStr++) {
    n *= 10;
    n += *pStr - '0';
  }
  if (g) n *= -1;
  return n;
}
