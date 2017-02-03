//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Getdents
.global Lseek
.global Rmdir
.global Mkdir
.global Unlink
.global Mount

Mkdir:
	push rbp
	mov rbp,rsp
  
	mov rax,136  
	syscall
  
	leave
	ret 

Rmdir:
	push rbp
	mov rbp,rsp
  
	mov rax,137  
	syscall
  
	leave
	ret 
	
Unlink:
	push rbp
	mov rbp,rsp
  
	mov rax,10  
	syscall
  
	leave
	ret 

Getdents:
	push rbp
	mov rbp,rsp
  
	mov rax,0x110  
	syscall
  
	leave
	ret 
	
Lseek:
	push rbp
	mov rbp,rsp
  
	mov rax,478  
	syscall
  
	leave
	ret 
	
Mount:
  push rbp
  mov rbp,rsp
  
  mov rax,21  
  mov r10, rcx
  syscall
  
  leave
  ret
