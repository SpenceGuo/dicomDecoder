using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public class UL : VR
    {
        public UL(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            Int32 value = (Int32)GetUInt(data, ref idx);
            return value.ToString();
        }
    }
}
