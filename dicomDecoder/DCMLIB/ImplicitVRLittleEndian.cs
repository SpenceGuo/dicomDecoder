using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class ImplicitVRLittleEndian : TransferSyntax
    {
        public ImplicitVRLittleEndian()
        {
            isExplicit = false;
            isBE = false;
            uid = "1.2.840.10008.1.2";
            name = "implicitVRLittleEndian";
        }
    }
}
