using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class SL : VR
    {
        public SL(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            Int64 value = (Int64)GetUShort(data, ref idx);
            return value.ToString();
        }
    }
}
