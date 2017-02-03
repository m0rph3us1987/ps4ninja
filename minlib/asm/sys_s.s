//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Sysctl

Sysctl:
  push rbp
  mov rbp,rsp
  
  mov rax,202  
  mov r10, rcx
  syscall
  
  leave
  ret
