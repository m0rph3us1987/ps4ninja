/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 *                        minlib by m0rph3us1987                       
 * 
 * 	parts of this file are taken from fail0verflow's ps4-kexec
 * 
 * 		 https://github.com/fail0verflow/ps4-kexec
 * ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

#include "../include/minlib.h"

#define KERNBASE    0xffffffff80000000ull
#define KERNSIZE    0x2000000
#define NULL 0

static const u8 ELF_IDENT[9] = "\x7f" "ELF\x02\x01\x01\x09\x00";

static Elf64_Ehdr *findElfHeader();
static Elf64_Dyn *elf_get_dyn(Elf64_Ehdr *ehdr);
static int elf_parse_dyn(Elf64_Dyn *dyn);
void *kernel_resolve(const char *name);
static Elf64_Sym *symtab;
static char *strtab;
static size_t strtab_size;

void *resolve_function(const char *name)
{
    Elf64_Ehdr *ehdr = findElfHeader();
	Elf64_Dyn *dyn = elf_get_dyn(ehdr);
	if(elf_parse_dyn(dyn)){
	    return kernel_resolve(name);
    }

    return NULL;
}

static Elf64_Ehdr *findElfHeader(){
  for (uintptr_t p = KERNBASE; p < KERNBASE + KERNSIZE; p += 0x4000) {
        Elf64_Ehdr *ehdr = (Elf64_Ehdr *)p;
        if (!Memcmp(ehdr->e_ident, ELF_IDENT, sizeof(ELF_IDENT))) {
            for (size_t i = 0; i < ehdr->e_phnum; i++) {
                Elf64_Phdr *phdr = (Elf64_Phdr *)(p + ehdr->e_phoff) + i;
                if (phdr->p_type == PT_PHDR) {
					return (Elf64_Ehdr *)((u64)phdr->p_vaddr - (u64)ehdr->e_phoff);
                }
            }
        }
    }
    return NULL;
}

static Elf64_Dyn *elf_get_dyn(Elf64_Ehdr *ehdr)
{
    Elf64_Phdr *phdr = (Elf64_Phdr *)((uintptr_t)ehdr + ehdr->e_phoff);
    for (size_t i = 0; i < ehdr->e_phnum; i++, phdr++) {
        if (phdr->p_type == PT_DYNAMIC) {
            return (Elf64_Dyn *)phdr->p_vaddr;
        }
    }
    return NULL;
}

static int elf_parse_dyn(Elf64_Dyn *dyn)
{
    for (Elf64_Dyn *dp = dyn; dp->d_tag != DT_NULL; dp++) {
        switch (dp->d_tag) {
            case DT_SYMTAB:
                symtab = (Elf64_Sym *)dp->d_un.d_ptr;
                break;
            case DT_STRTAB:
                strtab = (char *)dp->d_un.d_ptr;
                break;
            case DT_STRSZ:
                strtab_size = dp->d_un.d_val;
                break;
        }
    }
    return symtab && strtab && strtab_size;
}

void *kernel_resolve(const char *name)
{
    for (Elf64_Sym *sym = symtab; (uintptr_t)(sym + 1) < (uintptr_t)strtab; sym++) {
        if (!Strcmp((char *)name, &strtab[sym->st_name])) {
            return (void *)sym->st_value;
        }
    }
    return NULL;
}