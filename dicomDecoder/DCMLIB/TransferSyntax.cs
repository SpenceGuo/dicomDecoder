using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public abstract class TransferSyntax
    {
        public bool isBE;
        public bool isExplicit;
        public string uid;
        public string name;
        protected VR vrdecoder;
        private DicomDictionary dictionary;
        protected VRFactory vrfactory;

        public TransferSyntax()
        {
            //初始化数据字典类对象
            //dictionary = new DicomDictionary(".\\dicom.dic");
            dictionary = new DicomDictionary();
            vrfactory = new VRFactory(this);
            vrdecoder = new UL(this);
        }

        public virtual DCMAbstractType Decode(byte[] data, ref uint idx)
        {
            DCMDataElement element = new DCMDataElement();
            //vrdecoder = new US(this);
            //读取TAG
            element.gtag = vrdecoder.GetUShort(data, ref idx);
            element.etag = vrdecoder.GetUShort(data, ref idx);

            if (element.gtag == 0xfffe && element.etag == 0xe000) //处理SQ的三个特殊标记
            {
                DCMDataItem sqitem = new DCMDataItem(this);
                uint length = vrdecoder.GetUInt(data, ref idx); //不能用GetLength
                uint offset = idx;
                while (idx - offset < length)
                {
                    DCMAbstractType sqelem = Decode(data, ref idx);  //递归
                    if (length == 0xffffffff && sqelem.gtag == 0xfffe && sqelem.etag == 0xe00d) //条目结束标记
                        break;
                    sqitem.items.Add(sqelem);
                }
                return sqitem;
            }
            else if (element.gtag == 0xfffe && element.etag == 0xe0dd)  //序列结束标记
            {
                element.vr = "UL";
                element.length = vrdecoder.GetUInt(data, ref idx);  //不能用GetLength
                return element;
            }


            //查数据字典得到VR,Name,VM
            element.vr = vrdecoder.GetVR(data, ref idx);

            DicomDictionaryEntry entry = dictionary.GetEntry(element.gtag, element.etag);

            if (entry != null)
            {
                if (element.vr == "") element.vr = entry.VR;
                element.name = entry.Keyword;
                element.vm = entry.VM;
            }
            else if (element.vr == "" && element.etag == 0)
            {
                element.vr = "US";
            }
            //根据得到的VR实例化具体vr类，此处暂时用vrdecode(即US类对象)
            element.vrparser = vrfactory.GetVR(element.vr);
            vrdecoder = element.vrparser;
            //读取值长度
            element.length = vrdecoder.GetLength(data, ref idx);
            //读取值
            element.value = vrdecoder.GetValue(data, ref idx, element.length);
            return element;
        }

    }
}
