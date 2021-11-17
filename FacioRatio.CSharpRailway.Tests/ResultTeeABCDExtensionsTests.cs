using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTeeABCDExtensionsTests
    {
        [Fact]
        public void Tee_Action_Success()
        {
            var sut = Result.Ok<(int, int, int, int)>((1, 2, 3, 4));

            var i = 0;
            var result = sut.Tee((a, b, c, d) => i = a * b * c * d);
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3, 4), result.ValueOrFallback());
            Assert.Equal(24, i);
        }

        [Fact]
        public void Tee_Action_Failure()
        {
            var sut = Result.Fail<(int, int, int, int)>("fail");

            var i = 0;
            var result = sut.Tee((a, b, c, d) => i = a * b * c * d);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Success()
        {
            var sut = Result.Ok<(int, int, int, int)>((1, 2, 3, 4));

            var i = 0;
            var result = await sut.Tee((a, b, c, d) => Task.FromResult(i = a * b * c * d));
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3, 4), result.ValueOrFallback());
            Assert.Equal(24, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Failure()
        {
            var sut = Result.Fail<(int, int, int, int)>("fail");

            var i = 0;
            var result = await sut.Tee((a, b, c, d) => Task.FromResult(i = a * b * c * d));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }
    }
}
