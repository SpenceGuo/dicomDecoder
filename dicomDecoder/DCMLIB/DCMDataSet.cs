using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public class DCMDataSet : DCMAbstractType
    {
        public List<DCMAbstractType> items;
        protected TransferSyntax syntax;
        public DCMDataSet(TransferSyntax ts)   //传输语法由构造函数传入
        {
            syntax = ts;
            items = new List<DCMAbstractType>();
        }

        public override string ToString(string head)
        {
            string str = "";
            foreach (DCMAbstractType item in items)
            {
                if (item != null)
                {
                    if (str != "") str += "\n";  //两个数据元素之间用换行符分割
                    str += item.ToString(head);
                }
            }
            return str;
        }

        public virtual List<DCMAbstractType> Decode(byte[] data, ref uint idx) //解码方法
        {
            while (idx < data.Length)
            {
                DCMAbstractType item = null;
                item = syntax.Decode(data, ref idx);//根据传入的传输语法
                items.Add(item);
            }
            return items;
        }
    }
}
