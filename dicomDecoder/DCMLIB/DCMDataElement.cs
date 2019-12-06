using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public class DCMDataElement : DCMAbstractType
    {
        public override string ToString(string head)
        {
            string str = head;
            str += gtag.ToString("X4") + "," + etag.ToString("X4") + "\t";
            str += vr + "\t";
            str += name + "\t";
            str += length.ToString();
            str += "\t";
            //value怎么返回字符串需要根据不同VR
            str += vrparser.GetString(value, head);
            //str += “”;
            return str;

        }
    }
}
