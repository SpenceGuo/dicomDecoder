﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicom_exec4
{
    class UN:VR
    {
        public UN(TransferSyntax syntax) : base(syntax) { }

        public override string GetString(byte[] data, string head)
        {
            string value = ASCIIEncoding.Default.GetString(data);
            return value.ToString();
        }
    }
}
