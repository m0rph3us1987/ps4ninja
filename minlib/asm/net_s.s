//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                       minlib by m0rph3us1987                       
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.intel_syntax noprefix
.text

.global Socket
.global connect_sys
.global Recv
.global Accept
.global Listen
.global Bind

Socket:
  push rbp
  mov rbp,rsp
  
  mov rax,97
  syscall
  
  leave
  ret 

connect_sys:
  push rbp
  mov rbp,rsp
  
  mov rax,98
  syscall
  
  leave
  ret 
  
Recv:
	push rbp
	mov rbp,rsp

	mov rax,29
	syscall

	leave
	ret 
	
Accept:
	push rbp
	mov rbp,rsp

	mov rax,30
	syscall

	leave
	ret
	
Listen:
	push rbp
	mov rbp,rsp

	mov rax,106
	syscall

	leave
	ret
	
Bind:
	push rbp
	mov rbp,rsp

	mov rax,104
	syscall

	leave
	ret
