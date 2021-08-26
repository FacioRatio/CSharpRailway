using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class BindTTests
    {
        [Fact]
        public async Task Bind_ReturnsValueWhenSuccess()
        {
            {
                var sut = Result.Ok("Arthur");
                var result = sut.Bind(_ => Result.Ok("Dent"));
                Assert.Equal("Dent", result.ValueOrFallback());
            }
            {
                var sut = Result.Ok("Arthur");
                var result = await sut.Bind(_ => Task.FromResult(Result.Ok("Dent")));
                Assert.Equal("Dent", result.ValueOrFallback());
            }
            {
                var sut = Result.Ok("Arthur");
                var result = sut.Bind(_ => "Dent");
                Assert.Equal("Dent", result.ValueOrFallback());
            }
            {
                var sut = Result.Ok("Arthur");
                var result = await sut.Bind(_ => Task.FromResult("Dent"));
                Assert.Equal("Dent", result.ValueOrFallback());
            }
        }

        [Fact]
        public async Task Bind_ReturnsFailureOfTargetTypeWhenFailure()
        {
            {
                var sut = Result.Fail("Ford");
                var result = sut.Bind(_ => Result.Ok("Prefect"));
                Assert.Equal("Ford", result.Error.Message);
                Assert.IsType<string>(result.ValueOrFallback("Zaphod"));
            }
            {
                var sut = Result.Fail("Ford");
                var result = await sut.Bind(_ => Task.FromResult(Result.Ok("Prefect")));
                Assert.Equal("Ford", result.Error.Message);
                Assert.IsType<string>(result.ValueOrFallback("Zaphod"));
            }
            {
                var sut = Result.Fail("Ford");
                var result = sut.Bind(_ => "Prefect");
                Assert.Equal("Ford", result.Error.Message);
                Assert.IsType<string>(result.ValueOrFallback("Zaphod"));
            }
            {
                var sut = Result.Fail("Ford");
                var result = await sut.Bind(_ => Task.FromResult("Prefect"));
                Assert.Equal("Ford", result.Error.Message);
                Assert.IsType<string>(result.ValueOrFallback("Zaphod"));
            }
        }
    }
}
