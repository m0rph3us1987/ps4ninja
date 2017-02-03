#++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#                       minlib by m0rph3us1987                       
#++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

ifndef Ps4Sdk
ifdef ps4sdk
Ps4Sdk := $(ps4sdk)
endif
ifdef PS4SDK
Ps4Sdk := $(PS4SDK)
endif
ifndef Ps4Sdk
$(error Neither PS4SDK, Ps4Sdk nor ps4sdk set)
endif
endif

CC		:=	clang
AS		:=	gcc
AR	:=	ar
OBJCOPY	:=	objcopy
ODIR	:=	build
SDIR	:=	c
ASMSRCDIR	:=	asm
CFLAGS	:=	$(IDIRS) -I$(PS4SDK)/include -D MRP_NET_DBG -O3 -std=c99 -w -fno-builtin -nostartfiles -nostdlib -m64 -mabi=sysv -mcmodel=large -fno-stack-protector
#CFLAGS	:=	$(IDIRS) -I$(PS4SDK)/include -O3 -std=c99 -w -fno-builtin -nostartfiles -nostdlib -masm=intel -m64 -mabi=sysv -mcmodel=large -fno-stack-protector
SFLAGS	:=	-nostartfiles -nostdlib -march=btver2 -mtune=btver2 
LFLAGS	:=	$(LDIRS) -Xlinker -T linker.x -Wl,--build-id=none -Ttext=$(TEXT) -Tdata=$(DATA) -fno-stack-protector
CFILES	:=	$(wildcard $(SDIR)/*.c)
SFILES	:=	$(wildcard $(ASMSRCDIR)/*.s)
OBJS	:=	$(patsubst $(ASMSRCDIR)/%.s, $(ODIR)/%.o, $(SFILES)) $(patsubst $(SDIR)/%.c, $(ODIR)/%.o, $(CFILES)) $(patsubst $(SDIR)/%.s, $(ODIR)/%.o, $(SFILES)) 

TARGET = $(Ps4Sdk)/lib/libminlib.a

$(TARGET): $(ODIR) $(OBJS)
	$(AR) rcs $(TARGET) $(OBJS)
	rm -f $(ODIR)/*.o

$(ODIR)/%.o: $(SDIR)/%.c 
	$(CC) -c -o $@ $< $(CFLAGS) -fno-stack-protector

$(ODIR)/%.o: $(ASMSRCDIR)/%.s
	$(AS) -c -o $@ $< $(SFLAGS)

$(ODIR):
	@mkdir $@

ps4ninja:
	cd ../ps4ninja_ps4/ps4ninja/ && $(MAKE) clean && $(MAKE)

.PHONY: clean

clean:
	rm -f $(TARGET) $(ODIR)/*.o
	rm -f example
