//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Ptrace

Ptrace:
  push rbp
  mov rbp,rsp
  
  mov rax,26  
  mov r10, rcx
  syscall
  
  leave
  ret
