namespace QMKCompilerAPI
{
    // ReSharper disable once InconsistentNaming
    public static class Constants
    {
        public const string KEYBOARD_PARAM = "keyboard";
        public const string COMPILE_CHECK_PARAM = "jobid";

        public const string BASE = "http://compile.qmk.fm/v1";
        public const string KEYBOARDS = "/keyboards";
        public const string KEYBOARD = KEYBOARDS + "/{" + KEYBOARD_PARAM + "}";
        public const string COMPILE = "/compile";
        public const string COMPILE_CHECK = "/compile/{" + COMPILE_CHECK_PARAM + "}";
    }
}