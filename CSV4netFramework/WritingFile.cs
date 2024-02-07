﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSV4netFramework
{
    public class WritingFile
    {
        public static string version = "1.1";

        public static void WriteFile(List<string> list, string path, string encoding = "utf-8")
        {
            using (StreamWriter sr = new StreamWriter(path, false, Encoding.GetEncoding(encoding)))
            {
                foreach (string str in list)
                {
                    sr.WriteLine(str);
                }
            }
        }

        public static void WriteCSV(List<string[]> list, string path, bool isDoubleQuotation = false, char separate = ',', string encoding = "utf-8")
        {
            List<string> writeList = new List<string>();
            foreach (string[] strArray in list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string str in strArray)
                {
                    if (isDoubleQuotation)
                    {
                        sb.Append("\"" + str + "\"" + separate);
                    }
                    else
                    {
                        if (str.Contains("\r\n") || str.Contains("\n"))
                        {
                            sb.Append("\"" + str + "\"" + separate);
                        }
                        else
                        {
                            sb.Append(str + separate);
                        }
                    }
                }
                string text = sb.ToString();
                writeList.Add(text.Remove(text.Length - 1));
            }
            WriteFile(writeList, path, encoding);
        }
    }
}
