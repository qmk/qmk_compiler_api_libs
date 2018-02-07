using System;

namespace QMKCompilerAPI
{
    public class CompileRequestResult
    {
        public bool Enqueued { get; set; }
        public Guid JobId { get; set; }
    }
}