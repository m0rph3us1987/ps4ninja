/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */ 

#include "../include/minlib.h"
#include "../include/tinystdio/tinystdio.h"

void PrintInt16(int value, int base)
{
  char buff[8];
  Itoa(value, buff, 8, base);
  PrintStr(buff);
  return;
}

void DebugPrint(const char* format, ...)
{
#ifdef MRP_CONSOLE_DBG
	int fd = 0;
	
	char tmpBuff[4096];
	
	va_list ap;

	va_start(ap, format);
	tfp_vsprintf(tmpBuff, format, ap);
	va_end(ap);
	
	Write(fd,tmpBuff,Strlen(tmpBuff));
	return;
#endif
#ifdef MRP_NET_DBG

	//int fd = Connect("192.168.1.150",30);
	char tmpBuff[4096];
	
	va_list ap;

	va_start(ap, format);
	tfp_vsprintf(tmpBuff, format, ap);
	va_end(ap);
	
	//Write(fd,tmpBuff,Strlen(tmpBuff));
	//Close(fd);
	return;
#endif
}

void DebugKLogPrint(const char* format, ...)
{
#ifdef MRP_NET_DBG

	int fd = Connect("192.168.1.150", 33);

	char tmpBuff[4096];

	va_list ap;

	va_start(ap, format);
	tfp_vsprintf(tmpBuff, format, ap);
	va_end(ap);

	Write(fd, tmpBuff, Strlen(tmpBuff));
	Close(fd);
	return;
#endif
}