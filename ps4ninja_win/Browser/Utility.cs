using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PS4FileNinja
{
    public class Utility
    {
        public static void DumpToFile(string Filename, byte[] Data)
        {
            if (File.Exists(Filename))
                File.Delete(Filename);

            FileStream fs = new FileStream(Filename, FileMode.CreateNew, FileAccess.Write);
            fs.Write(Data, 0, Data.Length);
            fs.Close();
        }

        public static byte[] ReadMemory(UInt64 addr, UInt64 len, TcpClient client)
        {
            byte[] tmp = new byte[18];

            Array.Copy(BitConverter.GetBytes((UInt16)2804), 0, tmp, 0, 2);
            Array.Copy(BitConverter.GetBytes(addr), 0, tmp, 2, 8);
            Array.Copy(BitConverter.GetBytes(len), 0, tmp, 2 + 8, 8);
            return Network.SendCommand64(tmp, false, "", client, true);
        }

        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static List<Dent> ResolveDents(byte[] Dents)
        {
            List<Dent> Result = new List<Dent>();

            int DStart = 0;
            int Dlen = 0;
            int Dend = 0;

            if (Dents == null)
                return null;

            if (Dents.Length > 0)
            {
                while (DStart < Dents.Length)
                {
                    try
                    {
                        Dlen = BitConverter.ToInt16(Dents, DStart + 4);

                        if (Dlen == 0)
                            break;

                        Dend = DStart + Dlen;

                        string tmpName = ASCIIEncoding.ASCII.GetString(Dents, DStart + 8, (int)Dents[DStart + 7]);
                        int Type = (int)Dents[DStart + 6];
                        Dent d = new Dent();
                        d.Name = tmpName;
                        d.Type = Type;
                        Result.Add(d);
                        DStart = Dend;
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            return Result;
        }
    }
}
