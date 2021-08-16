using System;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class EachTTests
    {
        [Fact]
        public void Each_ReturnsSuccessWhenAllSucceed()
        {
            static Result<Empty> f(int j) => j < 3 ? Result.Ok() : Result.Fail("Zarquon!");
            var ints = new int[3] { 0, 1, 2 };

            var result = ints.Each(f);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Each_ReturnsFailureWhenAnyFail()
        {
            static Result<Empty> f(int j) => j == 0 ? Result.Ok() : Result.Fail("Zarquon!");
            var ints = new int[3] { 0, 1, 2 };

            var result = ints.Each(f);
            Assert.False(result.IsSuccess);
            var error = result.Error as AggregateException;
            Assert.Equal(2, error.InnerExceptions.Count);
            Assert.Equal("Zarquon!", error.InnerExceptions[0].Message);
            Assert.Equal("Zarquon!", error.InnerExceptions[1].Message);
        }

        //!!and more
    }
}
