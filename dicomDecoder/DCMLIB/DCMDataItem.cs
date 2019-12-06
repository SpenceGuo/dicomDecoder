using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public class DCMDataItem : DCMDataSet
    {
        public DCMDataItem(TransferSyntax syntax) : base(syntax) { }
    }
}
