using System;
using System.Collections.Generic;

namespace QMKCompilerAPI
{
    public class Keyboard
    {
        public string Url { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Manufacturer { get; set; }
        public string Processor { get; set; }
        public string Bootloader { get; set; }
        public Dictionary<string, KeyboardLayout> Layouts { get; set; }
        public string KeyboardFolder { get; set; }
        public uint Width { get; set; }
        public string Maintainer { get; set; }
        public string KeyboardName { get; set; }
        public string Identifier { get; set; }
        public int Height { get; set; }
    }
}