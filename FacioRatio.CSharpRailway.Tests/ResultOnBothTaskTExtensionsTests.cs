using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultOnBothTaskTExtensionsTests
    {
        [Fact]
        public async Task OnBoth_ActionTaskResultT_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.OnBoth(r => i = r.ValueOrFallback(-1));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(1, i);
        }

        [Fact]
        public async Task OnBoth_ActionTaskResultT_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.OnBoth(r => i = r.ValueOrFallback(-1));
            Assert.True(result.IsFailure);
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal(-1, i);
        }

        [Fact]
        public async Task OnBoth_FuncTaskResultT_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.OnBoth(r => Task.FromResult(i = r.ValueOrFallback(-1)));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(1, i);
        }

        [Fact]
        public async Task OnBoth_FuncTaskResultT_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.OnBoth(r => Task.FromResult(i = r.ValueOrFallback(-1)));
            Assert.True(result.IsFailure);
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal(-1, i);
        }
    }
}
