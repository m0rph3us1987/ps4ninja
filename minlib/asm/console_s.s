//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global PrintStr

.extern Strlen

PrintStr:
  push rbp
  mov rbp,rsp
  
  push rdi
  
  call Strlen
  mov rdx,rax
  
  pop rdi  
  
  mov rax,0x04
  mov rsi,rdi
  mov rdi,0x01 
  syscall
  
  leave
  ret
