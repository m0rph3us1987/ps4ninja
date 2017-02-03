/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#ifndef SIG_KILL
	#define SIG_KILL 9
#endif

#ifndef SIGCONT
	#define SIGCONT         19      /* continue a stopped process */
#endif

 
#ifndef MRP_THREAD
#define MRP_THREAD 0

#include <bsm/audit.h>

int Fork();
int Getpid();
int Kill();



struct sendto_args {
	int	s;
	void *	buf;
	unsigned long long	len;
	int	flags;
	void *	to;
	int	tolen;
};

struct ucred {
	unsigned long useless1;
	unsigned long cr_uid;     // effective user id
	unsigned long cr_ruid;    // real user id
	unsigned long useless2;
	unsigned long useless3;
	unsigned long cr_rgid;    // real group id
	unsigned long useless4;
	void *useless5;
	void *useless6;
	void *cr_prison;     // jail(2)
	void *useless7;
	unsigned long useless8;
	void *useless9[2];
	void *useless10;
	struct auditinfo_addr useless11;
	unsigned long *cr_groups; // groups
	unsigned long useless12;
};

struct proc {
	char useless[64];
	struct ucred *p_ucred;
};

struct thread {
	void *useless;
	struct proc *td_proc;
};

#endif

