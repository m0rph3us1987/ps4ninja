using System;
using System.Net.Sockets;
using System.IO;

namespace PS4FileNinja
{
    public class Commands
    {
        public static Int64 ps4ninja_write_kmem(UInt64 Addr, UInt64 Len, byte[] Data, TcpClient Client)
        {
            byte[] tmp = new byte[18 + Len];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2833), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt64)Addr), 0, 8);
            ns.Write(BitConverter.GetBytes((UInt64)Len), 0, 8);
            ns.Write(Data, 0, (int)Len);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToInt64(tmp, 0);
        }

        public static byte[] ps4ninja_read_kmem(short PID, UInt64 Addr, UInt64 len, TcpClient Client)
        {
            byte[] tmp = new byte[20];

            Array.Copy(BitConverter.GetBytes((UInt16)2832), 0, tmp, 0, 2);
            Array.Copy(BitConverter.GetBytes(PID), 0, tmp, 2, 2);
            Array.Copy(BitConverter.GetBytes(Addr), 0, tmp, 4, 8);
            Array.Copy(BitConverter.GetBytes(len), 0, tmp, 12, 8);
            return Network.SendCommand64(tmp, false, "", Client, true);
        }

        public static Int64 ps4ninja_mount_iso(string Filename, string Dirname, TcpClient Client)
        {
            byte[] tmp = new byte[6 + Filename.Length + Dirname.Length + 2];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2831), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)Filename.Length), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)Dirname.Length), 0, 2);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Filename), 0, Filename.Length);
            ns.Write(BitConverter.GetBytes((UInt16)0), 0, 1);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Dirname), 0, Dirname.Length);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_apply_kpf(byte[] kpf,TcpClient Client)
        {
            byte[] tmp = new byte[kpf.Length + 2];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2830), 0, 2);
            ns.Write(kpf, 0, kpf.Length);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_enable_rwx_mapping(TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2829;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_disable_rwx_mapping(TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2828;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_enable_userland_aslr(TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2827;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_disable_userland_aslr(TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2826;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_mkdir(string Dirname, TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2825;
            com.param = Dirname;

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static Int64 ps4ninja_receive_file(string Filename, UInt64 FileSize, UInt32 IP, UInt32 Port, TcpClient Client)
        {
            byte[] tmp = new byte[2 + 16 + 2 + Filename.Length + 1];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2824), 0, 2);
            ns.Write(BitConverter.GetBytes(FileSize),0,8);
            ns.Write(BitConverter.GetBytes(Port), 0, 4);
            ns.Write(BitConverter.GetBytes(IP), 0, 4);
            ns.Write(BitConverter.GetBytes((UInt16)Filename.Length), 0, 2);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Filename), 0, Filename.Length);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToInt64(tmp, 0);
        }

        public static Int64 ps4ninja_unmountsave(string Dirname, int DeviceID,TcpClient Client)
        {
            byte[] tmp = new byte[6 + Dirname.Length +1];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2823), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)DeviceID), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)Dirname.Length), 0, 2);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Dirname), 0, Dirname.Length);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToInt64(tmp, 0);
        }

        public static Int64 ps4ninja_mountsave(string Filename, string Dirname, TcpClient Client)
        {
            byte[] tmp = new byte[6 + Filename.Length + Dirname.Length + 2];

            MemoryStream ns = new MemoryStream(tmp);
            ns.Write(BitConverter.GetBytes((UInt16)2822), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)Filename.Length), 0, 2);
            ns.Write(BitConverter.GetBytes((UInt16)Dirname.Length), 0, 2);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Filename), 0, Filename.Length);
            ns.Write(BitConverter.GetBytes((UInt16)0), 0, 1);
            ns.Write(System.Text.Encoding.ASCII.GetBytes(Dirname), 0, Dirname.Length);
            ns.Close();

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return BitConverter.ToInt64(tmp, 0);
        }

        public static byte ps4ninja_exit_breakpoint(short pid, byte opcode, TcpClient Client)
        {
            byte[] tmp = new byte[5];

            Array.Copy(BitConverter.GetBytes((UInt16)2817), 0, tmp, 0, 2);
            Array.Copy(BitConverter.GetBytes(pid), 0, tmp, 2, 2);
            Array.Copy(BitConverter.GetBytes(opcode), 0, tmp, 4, 1);

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return tmp[0];
        }

        public static byte ps4ninja_set_breakpoint(short pid, UInt64 Addr, TcpClient Client)
        {
            byte[] tmp = new byte[12];

            Array.Copy(BitConverter.GetBytes((UInt16)2816), 0, tmp, 0, 2);
            Array.Copy(BitConverter.GetBytes(pid), 0, tmp, 2, 2);
            Array.Copy(BitConverter.GetBytes(Addr), 0, tmp, 4, 8);

            tmp = Network.SendCommand64(tmp, false, "", Client, true);
            return tmp[0];
        }

        public static byte[] ps4ninja_get_dents(string path, TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 0510;
            com.param = path;

            byte[] tmp = Structures.getBytesFromStruct(com);

            return Network.SendCommand(tmp, false, "", Client);
        }

        public static Int32 ps4ninja_attach(short pid, short traced, TcpClient Client)
        {
            byte[] tmp2 = new byte[6];

            Array.Copy(BitConverter.GetBytes((UInt16)2806), 0, tmp2, 0, 2);
            Array.Copy(BitConverter.GetBytes(pid), 0, tmp2, 2, 2);
            Array.Copy(BitConverter.GetBytes(traced), 0, tmp2, 4, 2);

            /*
            // Send ptrace attach command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2806;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            */
            tmp2 = Network.SendCommand(tmp2, false, "", Client);

            if (tmp2 != null)
                return BitConverter.ToInt32(tmp2, 0);
            else
                return -1;
        }

        public static Int32 ps4ninja_detach(short pid, TcpClient Client)
        {
            // Send ptrace detach command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2807;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            tmp2 = Network.SendCommand(tmp2, false, "", Client);

            if (tmp2 != null)
                return BitConverter.ToInt32(tmp2, 0);
            else
                return -1;
        }

        public static byte[] ps4ninja_read_proc_mem(short PID, UInt64 Addr, UInt64 len, TcpClient Client)
        {
            byte[] tmp = new byte[20];

            Array.Copy(BitConverter.GetBytes((UInt16)2808), 0, tmp, 0, 2);
            Array.Copy(BitConverter.GetBytes(PID), 0, tmp, 2, 2);
            Array.Copy(BitConverter.GetBytes(Addr), 0, tmp, 4, 8);
            Array.Copy(BitConverter.GetBytes(len), 0, tmp, 12, 8);
            return Network.SendCommand64(tmp, false, "", Client, true);
        }

        public static byte[] ps4ninja_read_regs(short pid, TcpClient Client)
        {
            // Send ptrace read regs command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2812;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            return Network.SendCommand64(tmp2, false, "", Client,true);
        }

        public static byte[] ps4ninja_write_regs(short pid, byte[] Regs, TcpClient Client)
        {
            // Send ptrace write regs command
            byte[] command = new byte[4 + Regs.Length];

            MemoryStream ms = new MemoryStream(command);
            BinaryWriter bw = new BinaryWriter(ms);

            bw.Write(Convert.ToUInt16(2818));
            bw.Write(Convert.ToUInt16(pid));
            bw.Write(Regs);

            bw.Close();
            ms.Close();

            return Network.SendCommand64(command, false, "", Client, true);
        }

        public static void ps4ninja_step(short pid, TcpClient Client)
        {
            // Send ptrace read regs command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2813;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            Network.SendCommand64(tmp2, false, "", Client, true);

            return;
        }

        public static void ps4ninja_suspend(short pid, TcpClient Client)
        {
            // Send ptrace read regs command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2814;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            Network.SendCommand64(tmp2, false, "", Client, true);

            return;
        }

        public static void ps4ninja_resume(short pid, TcpClient Client)
        {
            // Send ptrace read regs command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2815;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            Network.SendCommand64(tmp2, false, "", Client, true);

            return;
        }

        public static void ps4ninja_continue(short pid, TcpClient Client)
        {
            // Send ptrace read regs command
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2810;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            Network.SendCommand64(tmp2, false, "", Client, true);

            return;
        }

        public static void ps4ninja_kill_pid(short pid, TcpClient Client)
        {
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 9999;
            com.param = Convert.ToUInt16(pid);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            Network.SendCommand(tmp2, false, "", Client);
        }

        public static UInt64 ps4ninja_rmdir(string Dirname, TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2819;
            com.param = Dirname;

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp,0);
        }

        public static UInt64 ps4ninja_rmfile(string filename, TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2820;
            com.param = filename;

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static UInt64 ps4ninja_execve(string filename, TcpClient Client)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2821;
            com.param = filename;

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", Client, true);

            return BitConverter.ToUInt64(tmp, 0);
        }
    }
}
