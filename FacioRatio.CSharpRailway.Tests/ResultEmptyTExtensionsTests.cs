using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultEmptyTExtensionsTests
    {
        [Fact]
        public void Empty_Fails()
        {
            var sut = Result.Fail<int>("fail");

            var result = sut.Empty();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Empty_Succeeds()
        {
            var sut = Result.Ok<int>(1);

            var result = sut.Empty();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
        }
    }
}
