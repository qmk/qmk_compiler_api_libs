using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace QMKCompilerAPI.Test
{
    public class QMKCompilerAPITests : TestBase
    {
        [Fact]
        public async Task Get_keyboards_does_not_throw()
        {
            var result = await QMKCompilerAPI.GetKeyboardsAsync();
            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("planck/light")]
        [InlineData("planck/rev3")]
        [InlineData("planck/rev4")]
        [InlineData("planck/rev5")]
        [InlineData("planck/rev6")]
        public async Task Get_keyboard_does_not_throw(string name)
        {
            var result = await QMKCompilerAPI.GetKeyboardAsync(name);
            result.Should().NotBeNull();
            result.Layouts.Should().NotBeEmpty();

            foreach (var layout in result.Layouts.Values)
            {
                layout.Layout.Should().NotBeEmpty();
            }
            
        }

        [Theory]
        [InlineData("")]
        [InlineData("DoesNotExist")]
        [InlineData("plank/////ez")]
        [InlineData("planck\rev5")]
        public void Get_keyboard_throws_if_bad_keyboard(string name)
        {
            Func<Task> a = async () =>
            {
                await QMKCompilerAPI.GetKeyboardAsync(name);
            };
            a.Should().Throw<Exception>().And.Message.Contains(name);
        }
    }
}