/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef MRP_FS
#define MRP_FS 0

#ifndef SEEK_SET
#define	SEEK_SET	0	/* set file offset to offset */
#endif
#ifndef SEEK_CUR
#define	SEEK_CUR	1	/* set file offset to current plus offset */
#endif
#ifndef SEEK_END
#define	SEEK_END	2	/* set file offset to EOF plus offset */
#endif

#ifndef MNT_RDONLY
#define MNT_RDONLY      0x0000000000000001ULL /* read only filesystem */
#endif
#ifndef MNT_NOEXEC
#define MNT_NOEXEC      0x0000000000000004ULL /* can't exec from filesystem */
#endif
#ifndef MNT_AUTOMOUNTED
#define MNT_AUTOMOUNTED 0x0000000200000000ULL /* mounted by automountd(8) */
#endif


int Getdents(int fd, char *buf, int nbytes);
int Lseek(int fd, unsigned long offset, int whence);
int Rmdir(char *path);
int Unlink(char *path);
int CopyFile(char *srcFile, char *dstFile);
int Mkdir(char *path, int mode);
int Mount(char *type, char *path, int flags, char *data);

#endif
