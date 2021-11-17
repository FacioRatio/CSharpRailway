using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class NotFoundExceptionTests
    {
        [Fact]
        public void LooksGood()
        {
            var sut = new NotFoundException("Yo");

            Assert.Equal("Yo collection is empty.", sut.Message);
        }
    }
}
