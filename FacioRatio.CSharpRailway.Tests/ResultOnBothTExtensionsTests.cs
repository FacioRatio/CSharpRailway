using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultOnBothTExtensionsTests
    {
        [Fact]
        public void OnBoth_ActionResultT_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = sut.OnBoth(r => i = r.ValueOrFallback(-1));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(1, i);
        }

        [Fact]
        public void OnBoth_ActionResultT_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = sut.OnBoth(r => i = r.ValueOrFallback(-1));
            Assert.True(result.IsFailure);
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal(-1, i);
        }

        [Fact]
        public void OnBoth_FuncTaskResultT_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = sut.OnBoth(r => Task.FromResult(i = r.ValueOrFallback(-1)));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(1, i);
        }

        [Fact]
        public void OnBoth_FuncTaskResultT_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = sut.OnBoth(r => Task.FromResult(i = r.ValueOrFallback(-1)));
            Assert.True(result.IsFailure);
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal(-1, i);
        }
    }
}
