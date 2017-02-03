 /* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#include "../include/minlib.h"
 
 #define IP(a, b, c, d) (((a) << 0) + ((b) << 8) + ((c) << 16) + ((d) << 24))
 
unsigned int Ip_to_int (const char * ip)
{
  unsigned v = 0;
  int i;
  const char * start;

  start = ip;
  for (i = 0; i < 4; i++) {
      char c;
      int n = 0;
      while (1) {
	  c = * start;
	  start++;
	  if (c >= '0' && c <= '9') {
	      n *= 10;
	      n += c - '0';
	  }
	  else if ((i < 3 && c == '.') || i == 3) {
	      break;
	  }
	  else {
	      return 0;
	  }
      }
      if (n >= 256) {
	  return 0;
      }
      v *= 256;
      v += n;
  }
  return v;
}

int Connect(char *ip, int port)
{  
	int sock = Socket(AF_INET, SOCK_STREAM, 0);
  
	int Iip = HTONL(Ip_to_int(ip));
	port = HTONS(port);
  
	struct sockaddr_in server;

	server.sin_len = sizeof(server);
	server.sin_family = AF_INET;
	server.sin_addr.s_addr = Iip;
	server.sin_port = port;
	memset(server.sin_zero, 0, sizeof(server.sin_zero));
  
	int i = connect_sys(sock, &server, sizeof(server));
	return sock;
}

int Connect2(unsigned long ip, int port)
{  
  int sock = Socket(AF_INET, SOCK_STREAM, 0);

  int Iip = HTONL(ip);
  port = HTONS(port);
  
  struct sockaddr_in sockadr;  
  sockadr.sin_family = AF_INET;
  sockadr.sin_port = port;
  sockadr.sin_addr.s_addr = Iip;
  memset(sockadr.sin_zero, 0, sizeof(sockadr.sin_zero));
  
  connect_sys(sock, &sockadr, sizeof(sockadr));
  return sock;
}

int ReadBytes(int socket, unsigned long x, void* buffer)
{
	unsigned long bytesRead = 0;
    int result;
    while (bytesRead < x)
    {
        result = Read(socket, buffer + bytesRead, x - bytesRead);
		
		if (result < 0 )
			return -1;

		if(result == 0)
			bytesRead = x;
		else
			bytesRead += result;
    }

    return 0;
}
  