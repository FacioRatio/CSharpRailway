using System.Collections.Generic;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultNotAnyTExtensionsTests
    {
        [Fact]
        public void NotAny_ResultIEnumerable_Fails()
        {
            var sut = Result.Fail<IEnumerable<int>>("fail");

            var result = sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void NotAny_ResultIEnumerable_Fails_NotEmpty()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>() { 1 });

            var result = sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.IsType<NotEmptyException>(result.Error);
            Assert.Equal("Int32 collection is not empty.", result.Error.Message);
        }

        [Fact]
        public void NotAny_ResultIEnumerable_Succeeds()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>());

            var result = sut.NotAny();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback(new Empty()));
        }

        [Fact]
        public void NotAny_ResultList_Fails()
        {
            var sut = Result.Fail<List<int>>("fail");

            var result = sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void NotAny_ResultList_Fails_NotEmpty()
        {
            var sut = Result.Ok<List<int>>(new List<int>() { 1 });

            var result = sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.IsType<NotEmptyException>(result.Error);
            Assert.Equal("Int32 collection is not empty.", result.Error.Message);
        }

        [Fact]
        public void NotAny_ResultList_Succeeds()
        {
            var sut = Result.Ok<List<int>>(new List<int>());

            var result = sut.NotAny();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback(new Empty()));
        }
    }
}
