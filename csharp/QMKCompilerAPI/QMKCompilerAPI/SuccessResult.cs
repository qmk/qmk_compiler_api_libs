namespace QMKCompilerAPI
{
    public class SuccessResult : IResult
    {
        public string FirmwareFilename { get; set; }
        public byte[] Firmware { get; set; }
        public string Output { get; set; }
        public int Returncode { get; set; }
    }
}