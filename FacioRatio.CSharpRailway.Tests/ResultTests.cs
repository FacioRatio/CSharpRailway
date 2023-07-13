using System;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_IsSuccessWhenNoError()
        {
            var sut = Result.Ok();

            Assert.True(sut.IsSuccess);
            Assert.False(sut.IsFailure);
            Assert.Null(sut.Error);
        }

        [Fact]
        public void Result_IsFailureWhenError()
        {
            var sut = Result.Fail("panic");

            Assert.False(sut.IsSuccess);
            Assert.True(sut.IsFailure);
            Assert.NotNull(sut.Error);
            Assert.Equal("panic", sut.Error.Message);
        }

        [Fact]
        public void ValueOrFallback_ReturnsValueWhenSuccess()
        {
            var sut = Result.Ok("ok");
            Assert.Equal("ok", sut.ValueOrFallback());
        }

        [Fact]
        public void ValueOrFallback_ReturnsFallbackWhenFailure()
        {
            var sut = Result.Fail<string>("panic");
            Assert.Equal("DON'T PANIC", sut.ValueOrFallback("DON'T PANIC"));
        }

        [Fact]
        public void Ok_ReturnsSuccessfulEmptyResult()
        {
            var sut = Result.Ok();
            Assert.True(sut.IsSuccess);
            Assert.Null(sut.ValueOrFallback());
        }

        [Fact]
        public void Ok_WithType_ReturnsSuccessfulTypeResult()
        {
            var sut = Result.Ok("ok");
            Assert.True(sut.IsSuccess);
            Assert.Equal("ok", sut.ValueOrFallback());
        }

        [Fact]
        public void Fail_WithNullException_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Result.Fail(default(Exception)));
        }

        [Fact]
        public void Fail_WithNullString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Result.Fail(default(string)));
        }

        //!!add tests for OkTask and FailTask
    }
}
