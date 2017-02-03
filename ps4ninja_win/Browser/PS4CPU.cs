using System;
using System.IO;

namespace PS4FileNinja
{
    public class PS4CPU
    {
        public UInt64 r_r15;
        public UInt64 r_r14;
        public UInt64 r_r13;
        public UInt64 r_r12;
        public UInt64 r_r11;
        public UInt64 r_r10;
        public UInt64 r_r9;
        public UInt64 r_r8;
        public UInt64 r_rdi;
        public UInt64 r_rsi;
        public UInt64 r_rbp;
        public UInt64 r_rbx;
        public UInt64 r_rdx;
        public UInt64 r_rcx;
        public UInt64 r_rax;
        public UInt32 r_trapno;
        public UInt16 r_fs;
        public UInt16 r_gs;
        public UInt32 r_err;
        public UInt16 r_es;
        public UInt16 r_ds;
        public UInt64 r_rip;
        public UInt64 r_cs;
        public UInt64 r_rflags;
        public UInt64 r_rsp;
        public UInt64 r_ss;

        public PS4CPU()
        {
        }

        public PS4CPU(byte[] values)
        {
            MemoryStream ms = new MemoryStream(values);
            BinaryReader br = new BinaryReader(ms);

            this.r_r15 = br.ReadUInt64();
            this.r_r14 = br.ReadUInt64();
            this.r_r13 = br.ReadUInt64();
            this.r_r12 = br.ReadUInt64();
            this.r_r11 = br.ReadUInt64();
            this.r_r10 = br.ReadUInt64();
            this.r_r9 = br.ReadUInt64();
            this.r_r8 = br.ReadUInt64();
            this.r_rdi = br.ReadUInt64();
            this.r_rsi = br.ReadUInt64();
            this.r_rbp = br.ReadUInt64();
            this.r_rbx = br.ReadUInt64();
            this.r_rdx = br.ReadUInt64();
            this.r_rcx = br.ReadUInt64();
            this.r_rax = br.ReadUInt64();
            this.r_trapno = br.ReadUInt32();
            this.r_fs = br.ReadUInt16();
            this.r_gs = br.ReadUInt16();
            this.r_err = br.ReadUInt32();
            this.r_es = br.ReadUInt16();
            this.r_ds = br.ReadUInt16();
            this.r_rip = br.ReadUInt64();
            this.r_cs = br.ReadUInt64();
            this.r_rflags = br.ReadUInt64();
            this.r_rsp = br.ReadUInt64();
            this.r_ss = br.ReadUInt64();

            br.Close();
            ms.Close();
        }

        public byte[] Serialise()
        {
            byte[] result = new byte[0xb0];

            MemoryStream ms = new MemoryStream(result);
            BinaryWriter bw = new BinaryWriter(ms);

            bw.Write(this.r_r15);
            bw.Write(this.r_r14);
            bw.Write(this.r_r13);
            bw.Write(this.r_r12);
            bw.Write(this.r_r11);
            bw.Write(this.r_r10);
            bw.Write(this.r_r9);
            bw.Write(this.r_r8);
            bw.Write(this.r_rdi);
            bw.Write(this.r_rsi);
            bw.Write(this.r_rbp);
            bw.Write(this.r_rbx);
            bw.Write(this.r_rdx);
            bw.Write(this.r_rcx);
            bw.Write(this.r_rax);
            bw.Write(this.r_trapno);
            bw.Write(this.r_fs);
            bw.Write(this.r_gs);
            bw.Write(this.r_err);
            bw.Write(this.r_es);
            bw.Write(this.r_ds);
            bw.Write(this.r_rip);
            bw.Write(this.r_cs);
            bw.Write(this.r_rflags);
            bw.Write(this.r_rsp);
            bw.Write(this.r_ss);

            bw.Close();
            ms.Close();

            return result;
        }


    }
}
