using System.Collections.Generic;
using System.Collections.Specialized;

namespace QMKCompilerAPI
{
    public class CompileRequest
    {
        public string Keyboard { get; set; }
        public string Keymap { get; set; }
        public string Layout { get; set; }
        public string[][] Layers { get; set; }

        public CompileRequest(Keyboard keyboard, string keymap, string layout, string[][] layers)
        {
            Keyboard = keyboard.KeyboardName;
            Keymap = keymap;
            Layout = layout;
            Layers = layers;
        }
    }
}