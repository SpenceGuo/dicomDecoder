using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class OW:VR
    {
        public OW(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            string value = null;
            for(int i = 0; i < data.Length; i++)
            {
                value = value + GetUShort(data, ref idx).ToString();
            }
            return value.ToString();
        }
    }
}
