using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class ExplicitVRBigEndian : TransferSyntax
    {
        public ExplicitVRBigEndian()
        {
            isExplicit = true;
            isBE = true;
            uid = "1.2.840.10008.1.2.2";
            name = "explicitVRBigEndian";
        }
    }
}
