using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public abstract class LongVR : VR
    {
        public LongVR(TransferSyntax syntax) : base(syntax) { }

        public override uint GetLength(byte[] data, ref uint idx)
        {
            uint length = 0;
            
            if (syntax.isExplicit)
            {
                idx += 2;
                length = GetUInt(data, ref idx);
            }

            else
            {
                length = GetUInt(data, ref idx);
            }
            return length;
        }
    }
}
