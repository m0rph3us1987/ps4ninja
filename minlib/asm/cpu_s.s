//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Nanosleep

Nanosleep:
  push rbp
  mov rbp,rsp
  
  mov rax,240 
  syscall
  
  leave
  ret
