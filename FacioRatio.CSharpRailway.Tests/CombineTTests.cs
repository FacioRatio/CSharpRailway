using System;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class CombineTTests
    {
        [Fact]
        public void Combine_ReturnsAggregateError()
        {
            var r1 = Result.Fail("Ford");
            var r2 = Result.Fail("Trillian");
            var sut = r1.Combine(r2);

            Assert.IsType<AggregateException>(sut.Error);
            var error = sut.Error as AggregateException;
            Assert.Equal(2, error.InnerExceptions.Count);
            Assert.Equal("Ford", error.InnerExceptions[0].Message);
            Assert.Equal("Trillian", error.InnerExceptions[1].Message);
            Assert.Equal("One or more errors occurred. (Ford) (Trillian)", error.Message);
        }

        [Fact]
        public void Combine_ReturnsFailureWhenAnyFail()
        {
            var r1 = Result.Ok();
            var r2 = Result.Fail("Ford");
            var r3 = Result.Fail("Trillian");
            var sut = r1.Combine(r2).Combine(r3);

            Assert.False(sut.IsSuccess);
            var error = sut.Error as AggregateException;
            Assert.Equal(2, error.InnerExceptions.Count);
            Assert.Equal("Ford", error.InnerExceptions[0].Message);
            Assert.Equal("Trillian", error.InnerExceptions[1].Message);
            Assert.Equal("One or more errors occurred. (Ford) (Trillian)", error.Message);
        }

        [Fact]
        public void Combine_ReturnsAggregateSuccess()
        {
            var r1 = Result.Ok("Arthur");
            var r2 = Result.Ok("Zaphod");
            var r3 = Result.Ok("Marvin");
            var sut = r1.Combine(r2, (a, b) => $"{a} {b}").Combine(r3, (a, b) => $"{a} {b}");

            Assert.True(sut.IsSuccess);
            Assert.Equal("Arthur Zaphod Marvin", sut.ValueOrFallback());
        }

        //!!more CombineT methods
    }
}
