using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public class TransferSyntaxes
    {
        public TransferSyntax[] TSs = new TransferSyntax[3];
        public TransferSyntaxes()
        {
            TSs[0] = new ImplicitVRLittleEndian();
            TSs[1] = new ExplicitVRLittleEndian();
            TSs[2] = new ExplicitVRBigEndian();
        }
    }
}
