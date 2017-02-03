/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

 #ifndef NULL
	#define NULL 0
 #endif
 
// Console related stuff 
#include "console.h"

// String related stuff
#include "string.h"

// IO related stuff
#include "io.h"

// FS related stuff
#include "fs.h"

// Common stuff
#include "common.h"

// Network related stuff
#include "net.h"

// Memory related stuff
#include "mem.h"

// Thread related stuff
#include "thread.h"

// Kernel function resolver
#include "resolver.h"

// System related stuff
#include "sys.h"

// Process related stuff
#include "proc.h"

// Syscall related stuff
#include "syscalls.h"

// ptrace related stuff
#include "ptrace.h"

// types used to decrypt self
#include "types.h"

// self related stuff
#include "self.h"

// CPU related stuff
#include "cpu.h"

// Runtime kernel patches
#include "kpatch.h"

// Minlib complex functions
void dump_kernel(char *serverIP, int port, struct thread *td);
void dumpData(char *serverIP, int port, struct thread *td);
void StartServer(int port);
