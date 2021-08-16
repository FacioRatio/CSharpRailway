using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class BindTTests
    {
        [Fact]
        public void Bind_ReturnsValueWhenSuccess()
        {
            var sut = Result.Ok("Arthur");
            var result = sut.Bind(_ => "Dent");
            Assert.Equal("Dent", result.ValueOrFallback());
        }

        [Fact]
        public void Bind_ReturnsFailureOfTargetTypeWhenFailure()
        {
            var sut = Result.Fail("Ford");
            var result = sut.Bind(_ => "Prefect");
            Assert.Equal("Ford", result.Error.Message);
            Assert.IsType<string>(result.ValueOrFallback("Zaphod"));
        }

        //!!3 more BindT methods
    }
}
