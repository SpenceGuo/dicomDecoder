using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dicom_exec4
{
    class DicomDictionary
    {
        //string[] line = File.ReadAllLines(@"D:\learning\医用软件设计\实验\实验1\dicom.txt");
        List<DicomDictionaryEntry> dicomlist = new List<DicomDictionaryEntry>();

        public DicomDictionaryEntry GetEntry(ushort gtag, ushort etag)
        {
            DicomDictionaryEntry entry = new DicomDictionaryEntry();

            string str = null;
            str = "(" + gtag.ToString("X4") + "," + etag.ToString("X4") + ")";
            string tag = "\"" + str + "\"";

            for (int i = 0; i < dicomlist.Count; i++)
            {
                if (dicomlist[i].Tag == tag)
                {
                    entry = dicomlist[i];
                    break;
                }
            }
            return entry;
        }

        public DicomDictionary()
        {
            string[] line = File.ReadAllLines(@"D:\learning\医用软件设计\实验\实验1\dicom.txt");
            for (int i = 0; i < line.Length; i++)
            {
                DicomDictionaryEntry myEntry = new DicomDictionaryEntry();
                string[] oneline;
                oneline = line[i].Split('\t');
                myEntry.Tag = oneline[0];
                myEntry.Name = oneline[1];
                myEntry.Keyword = oneline[2];
                myEntry.VR = oneline[3];
                myEntry.VM = oneline[4];
                dicomlist.Add(myEntry);
            }
        }
    }
}
