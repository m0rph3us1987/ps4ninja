/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_IO
#define MRP_IO 0

#define	O_RDONLY	0x0000
#define	O_WRONLY	0x0001
#define	O_RDWR		0x0002
#define	O_ACCMODE	0x0003
#define O_CREAT     0x0200          /* create if nonexistent */
#define O_TRUNC     0x0400          /* truncate to zero length */

#define	O_DIRECTORY	0x00020000

int Open(char *path, int flags, int mode);
unsigned int Read(int handle, void *buff, int size);
unsigned int Write(int handle, void *buff, int size);
int Close(int handle); 

#endif
