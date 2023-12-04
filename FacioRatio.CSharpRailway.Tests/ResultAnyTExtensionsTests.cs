using System.Collections.Generic;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultAnyTExtensionsTests
    {
        [Fact]
        public void Any_ResultIEnumerable_Fails()
        {
            var sut = Result.Fail<IEnumerable<int>>("fail");

            var result = sut.Any();

            Assert.True(result.IsFailure);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Any_ResultIEnumerable_Fails_Empty()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>());

            var result = sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public void Any_ResultIEnumerable_Succeeds()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>() { 1 });

            var result = sut.Any();

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
        }

        [Fact]
        public void Any_ResultList_Fails()
        {
            var sut = Result.Fail<List<int>>("fail");

            var result = sut.Any();

            Assert.True(result.IsFailure);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Any_ResultList_Fails_Empty()
        {
            var sut = Result.Ok<List<int>>(new List<int>());

            var result = sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public void Any_ResultList_Succeeds()
        {
            var sut = Result.Ok<List<int>>(new List<int>() { 1 });

            var result = sut.Any();

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
        }
    }
}
