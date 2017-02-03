//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Wait4
.global _Wait
.global Execve
.global Fork
.global Getpid
.global Kill

Execve:
	push rbp
	mov rbp,rsp

	mov rax,59
	mov r10,rcx
	syscall

	leave
	ret

Wait4:
	push rbp
	mov rbp,rsp

	mov rax,7
	mov r10,rcx
	syscall

	leave
	ret
	
_Wait:
	push rbp
	mov rbp,rsp

	mov rax,84
	mov r10,rcx
	syscall

	leave
	ret

Fork:
  push rbp
  mov rbp,rsp
  
  mov rax,2 
  syscall
  
  leave
  ret
  
Getpid:
  push rbp
  mov rbp,rsp
  
  mov rax,20 
  syscall
  
  leave
  ret
  
Kill:
  push rbp
  mov rbp,rsp
  
  mov rax,37 
  syscall
  
  leave
  ret
