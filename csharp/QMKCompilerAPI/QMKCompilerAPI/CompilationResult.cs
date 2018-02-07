using System;

namespace QMKCompilerAPI
{
    public class CompilationStatus
    {
        public DateTime CreatedAt { get; set; }
        public DateTime EnqueuedAt { get; set; }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public IResult Result { get; set; }
    }
}