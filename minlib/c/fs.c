/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*                        minlib by m0rph3us1987
* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#include "../include/minlib.h"

int CopyFile(char *srcFile, char *dstFile)
{
	char tmpBuffer[4096];

	int srcFD = Open(srcFile, O_RDONLY, 0);	
	u64 srcFileSize = Lseek(srcFD, 0, SEEK_END);
	

	//Unlink(dstFile);
	int dstFD = Open(dstFile, O_WRONLY | O_CREAT | O_TRUNC, 755);

	u64 readBytes = 0;

	for (u64 written = 0; written < srcFileSize; )
	{
		Lseek(srcFD, written, SEEK_SET);

		readBytes = Read(srcFD, tmpBuffer, 4096);
		written += Write(dstFD, tmpBuffer, readBytes);
	}

	Close(srcFD);
	Close(dstFD);
	return 0;
}