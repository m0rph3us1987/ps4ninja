using System.Net.Sockets;
using System;
using System.Windows.Forms;
using System.IO;

namespace PS4FileNinja
{
    public class Network
    {
        public static byte ReadByte(Socket s)
        {
            byte[] tmp = new byte[1];

            while (s.Available == 0) { };
            s.Receive(tmp);

            return tmp[0];
        }

        public static UInt32 ReadU32(Socket s)
        {
            byte[] tmp = new byte[4];

            while (s.Available == 0) { };
            s.Receive(tmp);

            return BitConverter.ToUInt32(tmp, 0);
        }

        public static UInt64 ReadU64(Socket s)
        {
            byte[] tmp = new byte[8];

            while (s.Available == 0) { };
            s.Receive(tmp);

            return BitConverter.ToUInt64(tmp, 0);
        }

        public static byte[] ReadBytes(UInt32 size, Socket s)
        {
            byte[] Result = new byte[size];
            UInt32 receivedBytes = 0;

            while (receivedBytes < size)
            {
                while (s.Available == 0) { }

                byte[] tmp = new byte[s.Available];
                s.Receive(tmp);
                Array.Copy(tmp, 0, Result, receivedBytes, tmp.Length);
                receivedBytes += (UInt32)tmp.Length;
            }

            return Result;
        }

        public static void WriteByte(byte value, Socket s)
        {
            byte[] arr = new byte[1];
            arr[0] = value;
            s.Send(arr, 0, 1, SocketFlags.None);
        }

        public static void WriteU64(UInt64 value, Socket s)
        {
            byte[] tmp = BitConverter.GetBytes(value);
            Network.WriteBytes(tmp, s);
        }

        public static void WriteU32(UInt32 value, Socket s)
        {
            byte[] tmp = BitConverter.GetBytes(value);
            Network.WriteBytes(tmp, s);
        }

        public static void WriteBytes(byte[] value, Socket s)
        {
            s.Send(value);
        }

        public static byte[] SendCommand(byte[] command, bool withDialog, string LocalFile, TcpClient Client)
        {
            return SendCommand64(command, withDialog, LocalFile, Client, false);
        }

        public static UInt32 SendFileRequest(byte[] command, byte[] port, byte[] ip, TcpClient Client)
        {
            if (Client.Client.Available > 0)
            {
                byte[] tmp2 = new byte[Client.Client.Available];
                Client.Client.Receive(tmp2);
            }

            // Send data length and wait for OK
            Network.WriteU32((UInt32)command.Length, Client.Client);
            byte res = Network.ReadByte(Client.Client);

            if (res != 0x4f)
                return 0;

            // Send command and wait for OK
            Network.WriteBytes(command, Client.Client);
            res = Network.ReadByte(Client.Client);

            if (res != 0x4f)
                return 0;

            // Read answer length and send OK
            //byte[] tmp = null;

            UInt64 rdata = 0;

            rdata = Network.ReadU32(Client.Client);
            //tmp = new byte[rdata];
            
            // Reading answer...
            if (rdata != 0)
            {
                Client.Client.Send(port);
                Client.Client.Send(ip);
            }

            return Convert.ToUInt32(rdata);
        }

        public static byte[] SendCommand64(byte[] command, bool withDialog, string LocalFile, TcpClient Client, bool Response64Bit)
        {
            if (Client.Client.Available > 0)
            {
                byte[] tmp2 = new byte[Client.Client.Available];
                Client.Client.Receive(tmp2);
            }

            // Send data length and wait for OK
            Network.WriteU32((UInt32)command.Length, Client.Client);
            byte res = Network.ReadByte(Client.Client);

            if (res != 0x4f)
                return null;

            // Send command and wait for OK
            Network.WriteBytes(command, Client.Client);
            res = Network.ReadByte(Client.Client);

            if (res != 0x4f)
                return null;

            // Read answer length and send OK
            byte[] tmp = null;

            UInt64 rdata = 0;

            if (!withDialog)
            {
                if (!Response64Bit)
                    rdata = Network.ReadU32(Client.Client);
                else
                    rdata = Network.ReadU64(Client.Client);

                tmp = new byte[rdata];
            }
            else
            {
                rdata = Network.ReadU64(Client.Client);
            }
            // Reading answer...
            if (rdata != 0)
            {
                if (!withDialog)
                {
                    Network.WriteByte(Convert.ToByte(0x4f), Client.Client);
                    tmp = Network.ReadBytes((UInt32)rdata, Client.Client);
                }
                else
                {
                    frmTransfer trans = new frmTransfer(Client, rdata);
                    trans.LocalFile = LocalFile;
                    if (trans.ShowDialog() == DialogResult.Cancel)
                    {
                        if (trans.ClientPID != 0)
                        {
                            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
                            com.command = 9999;
                            com.param = Convert.ToUInt16(trans.ClientPID);

                            byte[] tmp2 = Structures.getBytesFromStruct(com);

                            SendCommand(tmp2, false, "", Client);
                            return null;
                        }
                    }
                    else
                        tmp = new byte[1]; // Return one dummy byte
                }
            }
            else
            {
                if(!withDialog)
                    tmp = null;
                else
                {
                    // If the filesize was zero, create an empty local file
                    if (File.Exists(LocalFile))
                        File.Delete(LocalFile);

                    FileStream fs = new FileStream(LocalFile, FileMode.CreateNew, FileAccess.ReadWrite);
                    fs.Close();

                    tmp = new byte[1];
                    tmp[0] = 0x4f;
                }
            }

            return tmp;
        }

        public static byte[] FlushSocket(TcpClient Client)
        {
            if (Client.Client.Available > 0)
            {
                byte[] tmp2 = new byte[Client.Client.Available];
                Client.Client.Receive(tmp2);
                return tmp2;
            }
            else
                return null;
        }

    }
}
