using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultEmptyTaskTExtensionsTests
    {
        [Fact]
        public async Task Empty_Fails()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var result = await sut.Empty();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Empty_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var result = await sut.Empty();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
        }
    }
}
