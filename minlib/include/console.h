 /* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_CONSOLE
#define MRP_CONSOLE 0
 
void PrintStr(char *str);
void PrintInt16(int value, int base);
int Sprintf(char *out, const char *format, ...);
int Printf(const char *format, ...);
void DebugPrint(const char* fmt, ...);

#endif
