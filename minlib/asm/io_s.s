//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Open
.global Read
.global Close
.global Write

Open:
  push rbp
  mov rbp,rsp
  
  mov rax,0x05  
  syscall
  
  leave
  ret 
  
Close:
  push rbp
  mov rbp,rsp
  
  mov rax,6
  syscall
  
  leave
  ret

Read:
  push rbp
  mov rbp,rsp
  
  mov rax,0x03
  syscall
  
  leave
  ret
  
Write:
  push rbp
  mov rbp,rsp
  
  mov rax,0x04
  syscall
  
  leave
  ret
