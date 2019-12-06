using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class SQ : LongVR
    {
        public SQ(TransferSyntax syntax) : base(syntax) { }

        public override byte[] GetValue(byte[] data, ref uint idx, uint length)
        {
            uint offset = idx;
            DCMDataSequence sq = new DCMDataSequence(syntax);
            while (idx - offset < length)
            {
                DCMAbstractType item = syntax.Decode(data, ref idx);
                if (length == 0xffffffff && item.gtag == 0xfffe && item.etag == 0xe0dd)
                    break;
                else
                    sq.items.Add((DCMDataItem)item);
            }
            GCHandle handle = GCHandle.Alloc(sq);
            IntPtr ptr = GCHandle.ToIntPtr(handle);
            return BitConverter.GetBytes(ptr.ToInt64());
        }
        public override string GetString(byte[] data, string head)
        {
            IntPtr ptr = new IntPtr(BitConverter.ToInt64(data, 0));
            GCHandle handle = GCHandle.FromIntPtr(ptr);
            DCMDataSequence sq = (DCMDataSequence)handle.Target;
            return sq.ToString(head + ">");
        }

    }
}
