using System;
using System.Threading.Tasks;
using Xunit;

namespace QMKCompilerAPI.Test
{
    public class KeyboardTests : TestBase
    {
        [Fact]
        public async Task CanGetKeyboards()
        {
            try
            {
                var result = await QMKCompilerAPI.GetKeyboardsAsync();
                Assert.NotEmpty(result);
            }
            catch (Exception)
            {
                Fail();
            }
        }

        [Theory]
        [InlineData("planck")]
        [InlineData("planck/light")]
        [InlineData("planck/rev3")]
        [InlineData("planck/rev4")]
        [InlineData("planck/rev5")]
        public async Task CanGetKeyboard(string name)
        {
            try
            {
                var result = await QMKCompilerAPI.GetKeyboardAsync(name);
                Assert.NotNull(result);
                Assert.NotEmpty(result.Layouts);

                foreach (var layout in result.Layouts.Values)
                {
                    Assert.NotEmpty(layout.Layout);
                }
            }
            catch (Exception)
            {
                Fail();
            }
        }
    }
}