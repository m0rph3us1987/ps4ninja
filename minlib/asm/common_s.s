//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Exit

Exit:
  push rbp
  mov rbp,rsp
  
  mov rax,0x01  
  syscall
  
  leave
  ret
  