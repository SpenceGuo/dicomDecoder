using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    public abstract class VR
    {
        protected TransferSyntax syntax;

        public VR(TransferSyntax syntax)
        {
            this.syntax = syntax;
        }

        public abstract string GetString(byte[] data, string head);

        public double GetDouble(byte[] data, ref uint idx)
        {
            double result = 0;
            byte[] buff = new byte[4];
            for (int i = 0; i < 8; i++, idx++)
            {
                buff[i] = data[idx];
            }
            if (syntax.isBE)
            {
                Array.Reverse(buff);
                result = BitConverter.ToDouble(buff, 0);
            }
            else
            {
                result = BitConverter.ToDouble(buff, 0);
            }
            return result;
        }

        public float GetFloat(byte[] data, ref uint idx)
        {
            float result = 0;
            byte[] buff = new byte[4];
            for (int i = 0; i < 4; i++, idx++)
            {
                buff[i] = data[idx];
            }
            if (syntax.isBE)
            {
                Array.Reverse(buff);
                result = BitConverter.ToSingle(buff, 0);
            }
            else
            {
                result = BitConverter.ToSingle(buff, 0);
            }
            return result;
        }

        public string GetGroupTag(byte[] data, ref uint idx)
        {
            string result = null;
            ushort gtag = 0;
            if (syntax.isBE)
            {
                gtag = (ushort)(data[idx] * 256 + data[idx + 1]);
            }
            else
            {
                gtag = (ushort)(data[idx] + data[idx + 1] * 256);
            }
            result = gtag.ToString("X4");
            idx += 2;
            return result;
        }

        public string GetElementTag(byte[] data, ref uint idx)
        {
            string result = null;
            ushort etag = 0;
            if (syntax.isBE)
            {
                etag = (ushort)(data[idx] * 256 + data[idx + 1]);
            }
            else
            {
                etag = (ushort)(data[idx] + data[idx + 1] * 256);
            }
            result = etag.ToString("X4");
            idx += 2;
            return result;
        }

        public string GetVR(byte[] data, ref uint idx)
        {
            string result = null;
            if (syntax.isExplicit)
            {
                byte[] b = new byte[2];
                b[0] = data[idx];
                b[1] = data[idx + 1];
                result = ASCIIEncoding.Default.GetString(b);
                idx += 2;
            }
            else
            {
                result = "";
            }
            return result;
        }

        public virtual uint GetLength(byte[] data, ref uint idx)
        {
            uint result = 0;
            if (syntax.isExplicit)
            {
                if (syntax.isBE)
                {
                    result = (ushort)(data[idx] * 256 + data[idx + 1]);
                }
                else
                {
                    result = (ushort)(data[idx] + data[idx + 1] * 256);
                }
                idx += 2;
            }
            else
            {
                if (syntax.isBE)
                {
                    result = (ushort)(data[idx] * 16777216 + data[idx + 1] * 65536 + data[idx + 2] * 256 + data[idx + 3]);
                }
                else
                {
                    result = (ushort)(data[idx + 3] * 16777216 + data[idx + 2] * 65536 + data[idx + 1] * 256 + data[idx]);
                }
                idx += 4;
            }
            return result;
        }

        public virtual byte[] GetValue(byte[] data, ref uint idx, uint length)
        {
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++, idx++)
            {
                result[i] = data[idx];
            }
            return result;
        }

        public uint GetUInt(byte[] data, ref uint idx)
        {
            uint result = 0;
            if (syntax.isBE)
            {
                result = (uint)(data[idx] * 16777216 + data[idx + 1] * 65536 + data[idx + 2] * 256 + data[idx + 3]);
            }
            else
            {
                result = (uint)(data[idx + 3] * 16777216 + data[idx + 2] * 65536 + data[idx + 1] * 256 + data[idx]);
            }
            idx += 4;
            return result;
        }

        public ushort GetUShort(byte[] data, ref uint idx)
        {
            ushort result = 0;
            if (syntax.isBE)
            {
                result = (ushort)(data[idx + 1] + data[idx] * 256);
            }
            else
            {
                result = (ushort)(data[idx] + data[idx + 1] * 256);
            }
            idx += 2;
            return result;
        }

    }
}
