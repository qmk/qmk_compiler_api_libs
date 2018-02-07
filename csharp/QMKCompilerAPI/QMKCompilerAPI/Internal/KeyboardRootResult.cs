using System;
using System.Collections.Generic;

namespace QMKCompilerAPI.Internal
{
    internal class KeyboardRootResult
    {
        public DateTime LastUpdated { get; set; }
        public Dictionary<string, Keyboard> Keyboards { get; set; }
    }
}