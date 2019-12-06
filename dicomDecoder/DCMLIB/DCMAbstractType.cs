using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public abstract class DCMAbstractType
    {
        public VR vrparser;
        public ushort gtag;
        public ushort etag;
        public string name;
        public string vr;
        public string vm;
        public uint length;
        public byte[] value;

        public abstract string ToString(string head);
    }
}
