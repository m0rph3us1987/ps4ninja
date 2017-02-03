using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS4FileNinja
{
    public class MasterEntry
    {
        public UInt16 FilenameLen;
        public string Filename;
        public UInt64 StartOffset;
        public UInt64 StartSegment;
        public UInt64 EndSegment;

        public MasterEntry()
        {

        }
    }
}
