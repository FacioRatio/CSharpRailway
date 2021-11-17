using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTeeABCExtensionsTests
    {
        [Fact]
        public void Tee_Action_Success()
        {
            var sut = Result.Ok<(int, int, int)>((1, 2, 3));

            var i = 0;
            var result = sut.Tee((a, b, c) => i = a * b * c);
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3), result.ValueOrFallback());
            Assert.Equal(6, i);
        }

        [Fact]
        public void Tee_Action_Failure()
        {
            var sut = Result.Fail<(int, int, int)>("fail");

            var i = 0;
            var result = sut.Tee((a, b, c) => i = a * b * c);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Success()
        {
            var sut = Result.Ok<(int, int, int)>((1, 2, 3));

            var i = 0;
            var result = await sut.Tee((a, b, c) => Task.FromResult(i = a * b * c));
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2, 3), result.ValueOrFallback());
            Assert.Equal(6, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Failure()
        {
            var sut = Result.Fail<(int, int, int)>("fail");

            var i = 0;
            var result = await sut.Tee((a, b, c) => Task.FromResult(i = a * b * c));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }
    }
}
