//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Mmap
.global Munmap

Mmap:
  push rbp
  mov rbp,rsp
  
  mov rax,477  
  mov r10, rcx
  syscall
  
  leave
  ret
  
Munmap:
  push rbp
  mov rbp,rsp
  
  mov rax,73  
  mov r10, rcx
  syscall
  
  leave
  ret
