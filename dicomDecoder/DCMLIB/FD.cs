using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class FD : VR
    {
        public FD(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            double value = GetDouble(data, ref idx);
            return value.ToString();
        }
    }
}
