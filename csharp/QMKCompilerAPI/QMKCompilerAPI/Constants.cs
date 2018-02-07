namespace QMKCompilerAPI
{
    // ReSharper disable once InconsistentNaming
    public static class Constants
    {
        public const string KEYBOARD_PARAM = "keyboard";

        public const string BASE = "http://compile.qmk.fm/v1";
        public const string KEYBOARDS = "/keyboards";
        public const string KEYBOARD = KEYBOARDS + "/{" + KEYBOARD_PARAM + "}";
    }
}
