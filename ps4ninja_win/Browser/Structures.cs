using System;
using System.Runtime.InteropServices;


namespace PS4FileNinja
{
    public class Structures
    {
        public struct TCPCommandComplex
        {
            [MarshalAs(UnmanagedType.U2, SizeConst = 2)]
            public UInt16 command;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string param;
        }

        public struct TCPCommandSimple
        {
            [MarshalAs(UnmanagedType.U2, SizeConst = 2)]
            public UInt16 command;
            [MarshalAs(UnmanagedType.U2, SizeConst = 2)]
            public UInt16 param;
        }

        public struct TCPCommandMem
        {
            [MarshalAs(UnmanagedType.U2, SizeConst = 2)]
            public UInt16 command;

            [MarshalAs(UnmanagedType.U8, SizeConst = 8)]
            public UInt64 adr;

            [MarshalAs(UnmanagedType.U8, SizeConst = 8)]
            public UInt64 len;
        }

        public static byte[] getBytesFromStruct(object str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }
    }
}
