using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultValueOrFallbackTaskTTests
    {
        [Fact]
        public async Task AsyncValueOrFallback_ReturnsValueWhenSuccess()
        {
            var sut = Task.FromResult(Result.Ok("ok"));
            Assert.Equal("ok", await sut.ValueOrFallback());
        }

        [Fact]
        public async Task AsyncValueOrFallback_ReturnsFallbackWhenFailure()
        {
            var sut = Task.FromResult(Result.Fail<string>("panic"));
            Assert.Equal("DON'T PANIC", await sut.ValueOrFallback("DON'T PANIC"));
        }
    }
}
