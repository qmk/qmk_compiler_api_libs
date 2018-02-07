namespace QMKCompilerAPI
{
    public interface IResult
    {
        string Output { get; set; }
        int Returncode { get; set; }
    }
}