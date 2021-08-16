using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class TeeTTests
    {
        [Fact]
        public void Tee_RunsActionWhenSuccess()
        {
            var sut = Result.Ok("Arthur");
            var x = "";
            var result = sut.Tee(_ => x = "Dent");
            Assert.Equal("Arthur", result.ValueOrFallback());
            Assert.Equal("Dent", x);
        }

        [Fact]
        public void Bind_SkipsActionWhenFailure()
        {
            var sut = Result.Fail("Ford");
            var x = "";
            var result = sut.Tee(_ => x = "Prefect");
            Assert.Equal("Ford", result.Error.Message);
            Assert.Equal("", x);
        }

        //!!3 more TeeT methods
    }
}
