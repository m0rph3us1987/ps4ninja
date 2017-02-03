/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
 
 #include "../include/minlib.h"

void GetProcesses(int s)
{
	/*
	char ClientAnswer[1];
	
	unsigned long long len;
	int mib[3];

	mib[0] = CTL_KERN;
	mib[1] = KERN_PROC;
	mib[2] = KERN_PROC_PROC;
	
	len = 0;
	if (Sysctl(mib, 3, NULL, &len, NULL, 0) < 0)
	{
		len = 0;
		Write(s, &len, 8);
		return;
	}
	
	unsigned char *procs = Mmap(NULL, len,  PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANON, -1 , 0);	
	Sysctl(mib, 3, procs, &len, NULL, 0);
	
	// Sending data size to client
	Write(s, &len, 8);
	
	// Reading answer from client
	Read(s, ClientAnswer, 1);
	
	if(ClientAnswer[0] == 'O')
	{
		Write(s, procs, len);
	}
  
	Munmap(procs, len);
	*/
	
	return;
}