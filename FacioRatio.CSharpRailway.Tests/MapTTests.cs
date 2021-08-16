using System;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class MapTTests
    {
        [Fact]
        public void Map_ReturnsListWhenAllSuccess()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Map(item => Result.Ok(item * 2));

            Assert.True(result.IsSuccess);
            var values = result.ValueOrFallback();
            Assert.Equal(3, values.Count);
            Assert.Equal(2, values[0]);
            Assert.Equal(4, values[1]);
            Assert.Equal(6, values[2]);
        }

        [Fact]
        public void Map_ReturnsFailureWhenAnyFail()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Map(item => item == 1
                ? Result.Fail<int>("Freeow!")
                : Result.Ok(item * 2));

            Assert.False(result.IsSuccess);
            Assert.Equal("Freeow!", result.Error.Message);
        }

        //!!and more
    }
}
