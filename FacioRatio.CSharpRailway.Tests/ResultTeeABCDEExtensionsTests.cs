using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTeeABCDEExtensionsTests
    {
        [Fact]
        public void Tee_Action_Success()
        {
            var sut = Result.Ok<(int, int, int, int, int)>((1, 2, 3, 4, 5));

            var i = 0;
            var result = sut.Tee((a, b, c, d, e) => i = a * b * c * d * e);
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3, 4, 5), result.ValueOrFallback());
            Assert.Equal(120, i);
        }

        [Fact]
        public void Tee_Action_Failure()
        {
            var sut = Result.Fail<(int, int, int, int, int)>("fail");

            var i = 0;
            var result = sut.Tee((a, b, c, d, e) => i = a * b * c * d * e);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Success()
        {
            var sut = Result.Ok<(int, int, int, int, int)>((1, 2, 3, 4, 5));

            var i = 0;
            var result = await sut.Tee((a, b, c, d, e) => Task.FromResult(i = a * b * c * d * e));
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3, 4, 5), result.ValueOrFallback());
            Assert.Equal(120, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Failure()
        {
            var sut = Result.Fail<(int, int, int, int, int)>("fail");

            var i = 0;
            var result = await sut.Tee((a, b, c, d, e) => Task.FromResult(i = a * b * c * d * e));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }
    }
}
