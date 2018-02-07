namespace QMKCompilerAPI
{
    public class ErrorResult : IResult
    {
        public string Output { get; set; }
        public int Returncode { get; set; }
        public string Cmd { get; set; }
    }
}