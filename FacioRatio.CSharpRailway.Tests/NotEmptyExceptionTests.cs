using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class NotEmptyExceptionTests
    {
        [Fact]
        public void LooksGood()
        {
            var sut = new NotEmptyException("Yo");

            Assert.Equal("Yo collection is not empty.", sut.Message);
        }
    }
}
