using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppTPL
{
    public class Document
    {
        public string DocumentName { get; set; }
        public byte[] DocumentContent { get; set; }
    }


    public class Template
    {
        public string TemplateID { get; set; }
        public byte[] TemplateContent { get; set; }
    }


}
