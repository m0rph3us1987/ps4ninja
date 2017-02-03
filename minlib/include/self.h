/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
 
#ifndef MRP_SELF
#define MRP_SELF 0

#define EI_NIDENT 16

typedef struct {
	unsigned char useless[0x18];
	u16 nents;
} Self_Header;

typedef struct {
    u8 e_ident[EI_NIDENT];
    u16 e_type;
    u16 e_machine;
    u32 e_version;
    u64 e_entry;
    u64 e_phoff;
    u64 e_shoff;
    u32 e_flags;
    u16 e_ehsize;
    u16 e_phentsize;
    u16 e_phnum;
    u16 e_shentsize;
    u16 e_shnum;
    u16 e_shtrndx;
} Elf64_Ehdr;

typedef struct {
    u32 p_type;
    u32 p_flags;
    u64 p_offset;
    u64 p_vaddr;
    u64 p_paddr;
    u64 p_filesz;
    u64 p_memsz;
    u64 p_align;
} Elf64_Phdr;

typedef struct {
	u32   sh_name;
	u32   sh_type;
	u64   sh_flags;
	u64   sh_addr;
	u64   sh_offset;
	u64   sh_size;
	u32   sh_link;
	u32   sh_info;
	u64   sh_addralign;
	u64   sh_entsize;
} Elf64_Shdr;

#define PT_LOAD     1
#define	PT_DYNAMIC  2
#define PT_PHDR     6
#define PT_NID      0x61000000

#define	DT_NULL     0
#define	DT_STRTAB   5
#define	DT_SYMTAB   6
#define	DT_STRSZ    10

typedef struct {
    s64 d_tag;
    union {
        u64 d_val;
        void *d_ptr;
    } d_un;
} Elf64_Dyn;

typedef struct {
    u32 st_name;
    u8 st_info;
    u8 st_other;
    u16 st_shndx;
    void *st_value;
    u64 st_size;
} Elf64_Sym;

unsigned char *DecryptSelf(void *selfAddr, int selfFD, u64 *selfSize);

#endif

