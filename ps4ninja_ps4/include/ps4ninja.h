/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        ps4ninja by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
#include "../../minlib/include/minlib.h"
 
 
#define NINJA_CMD_GET_DENTS 			510
#define NINJA_CMD_KILL_PID 				9999

#define NINJA_CMD_SEND_DEC_SELF 		2801
#define NINJA_CMD_SEND_FILE		 		2802
#define NINJA_CMD_GET_PROCS 			2803
#define NINJA_CMD_SEND_MEM				2804
#define NINJA_CMD_GET_PROC_VMMAP		2805
#define NINJA_CMD_ATTACH_PID			2806
#define NINJA_CMD_DETACH_PID			2807
#define NINJA_CMD_READ_PROC_MEM			2808
#define NINJA_CMD_WRITE_PROC_MEM		2809
#define NINJA_CMD_CONTINUE				2810
#define NINJA_CMD_STOP					2811
#define NINJA_CMD_READ_REGS				2812
#define NINJA_CMD_STEP					2813
#define NINJA_CMD_SUSPEND				2814
#define NINJA_CMD_RESUME				2815
#define NINJA_CMD_SET_BERAKPOINT		2816
#define NINJA_CMD_EXIT_BREAKPOINT		2817
#define NINJA_CMD_WRITE_REGS			2818
#define NINJA_CMD_RMDIR					2819
#define NINJA_CMD_RMFILE				2820
#define NINJA_CMD_EXECVE				2821
#define NINJA_CMD_MNTSAVE				2822
#define NINJA_CMD_UNMNTSAVE				2823
#define NINJA_CMD_RECEIVE_FILE			2824
#define NINJA_CMD_MKDIR					2825
#define NINJA_CMD_DISABLE_UASLR			2826
#define NINJA_CMD_ENABLE_UASLR			2827
#define NINJA_CMD_DISABLE_RWX			2828
#define NINJA_CMD_ENABLE_RWX			2829
#define NINJA_CMD_APPLY_KPF				2830
#define NINJA_CMD_MNT_ISO				2831
#define NINJA_CMD_READ_KMEM				2832
#define NINJA_CMD_WRITE_KMEM			2833

#define DEF_BUF_SIZE (4096 * 3) + 50

struct ps4ninja_kpf_uap
{
	u64 kpf;
};

struct ps4ninja_read_kmem_uap
{
	u64 kernel_addr;
	u64 user_addr;
	u64 len;
};

struct ps4ninja_write_kmem_uap
{
	unsigned long long kernel_addr;
	unsigned long long user_addr;
	unsigned long long len;
};

// Server related functions
void ps4ninja_start_server(int port);
void ps4ninja_handle_client(int s);

// Client request related functions 
void ps4ninja_client_answer64(u64 value, int s);
void ps4ninja_client_answer32(u32 value, int s);

// Process related functions
void ps4ninja_kill_pid(short pid, int socket);
void ps4ninja_get_procs(int s);
void ps4ninja_get_proc_vmmap(int pid, int s);

// FS related functions
void ps4ninja_get_dents(char *path, int socket);
void ps4ninja_rmdir(char *path, int s);
void ps4ninja_mkdir(char *path, int s);
void ps4ninja_rmfile(char *path, int s);
void ps4ninja_send_file(char *path, int s);
void ps4ninja_send_dec_self(char *path, int s);
void ps4ninja_receive_file(char *params, int s);
void ps4ninja_mount_iso(char *params, int s);

// Debugger related functions
void ps4ninja_attach_pid(short pid,short traced, int s);
void ps4ninja_detach_pid(short pid, int s);
void ps4ninja_read_proc_mem(short pid, void *addr, unsigned long long len, int socket);
void ps4ninja_write_proc_mem(short pid,void *srcAddr, void *addr, unsigned long long len, int socket);
void ps4ninja_continue_pid(short pid, int s);
void ps4ninja_read_regs(short pid, int s);
void ps4ninja_step(short pid, int s);
void ps4ninja_set_breakpoint(short pid, void *addr, int s);
void ps4ninja_exit_breakpoint(short pid, unsigned char originalOpcode, int s);
void ps4ninja_write_regs(short pid, struct regs *ps4Regs, int s);

// Savegame related functions
void ps4ninja_execve(char *path, int s);
void ps4ninja_mountsave(char *params, int s);
void ps4ninja_unmountsave(char *params, int s);

// Kernel patches
void ps4ninja_disable_userland_aslr(int s);
void ps4ninja_enable_userland_aslr(int s);
void ps4ninja_enable_rwx_mapping(int s);
void ps4ninja_disable_rwx_mapping(int s);


//Kernel patch related functions
void ps4ninja_kernel_disable_userland_aslr();
void ps4ninja_kernel_enable_userland_aslr();
void ps4ninja_kernel_disable_rwx_mapping();
void ps4ninja_kernel_enable_rwx_mapping();
void ps4ninja_apply_kpf(u64 addr, int s);
int ps4ninja_kernel_apply_kpf(void *td, void * uap);
void ps4ninja_kernel_read_kmem(struct ps4ninja_read_kmem_uap *uap);
void ps4ninja_kernel_write_kmem(struct thread *td, struct ps4ninja_write_kmem_uap *uap);
void ps4ninja_read_kmem(short pid, void *addr, unsigned long long len, int socket);
void ps4ninja_write_kmem(short pid, void *buff, void *kaddr, unsigned long long len, int socket);

// Closed source functions
extern int resolveMountFunctions();
extern int ps4ninja_mountSave_internal(char *saveName, char *dirName);
extern int ps4ninja_unmountSave_internal(char *dirName, int UnitNumber);
extern int ps4ninja_mountISO_internal(char *fileName, char *dirName);

