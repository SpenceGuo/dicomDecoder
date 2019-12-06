using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class US : VR
    {
        public US(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            Int32 value = (Int32)GetUShort(data, ref idx);
            return value.ToString();
        }
    }
}
