using System.Collections.Generic;

namespace QMKCompilerAPI
{
    public class Layers : List<List<string>> { }

    public class CompileRequest
    {
        public string Keyboard { get; set; }
        public string Keymap { get; set; }
        public string Layout { get; set; }
        public Layers Layers { get; set; }

        public CompileRequest(Keyboard keyboard, string keymap, string layout, Layers layers)
        {
            Keyboard = keyboard.KeyboardName;
            Keymap = keymap;
            Layout = layout;
            Layers = layers;
        }
    }
}