using Xunit;

namespace QMKCompilerAPI.Test
{
    public abstract class TestBase
    {
        public void Fail() => Assert.True(false);
    }
}