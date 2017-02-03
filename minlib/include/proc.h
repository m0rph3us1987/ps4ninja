/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#define WNOHANG         1       /* Don't hang in wait. */
#define WUNTRACED       2       /* Tell about stopped, untraced children. */
#define WSTOPPED        WUNTRACED   /* SUS compatibility */
#define WCONTINUED      4       /* Report a job control continued process. */
#define WNOWAIT         8       /* Poll only. Don't delete the proc entry. */
#define WEXITED         16      /* Wait for exited processes. */
#define WTRAPPED        32      /* Wait for a process to hit a trap or breakpoint */

 
int Wait4(int wpid, int *status, int	options, void *rusage);
int _Wait();
int Execve(char *fname, char **argv, char **envv);
