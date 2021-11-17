using System.Collections.Generic;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultLastTExtensionsTests
    {
        [Fact]
        public void Last_IEnumerable_Fails()
        {
            var sut = Result.Fail<IEnumerable<int>>("fail");

            var result = sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Last_IEnumerable_Fails_NotFound()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>());

            var result = sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public void Last_IEnumerable_Succeeds()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>() { 1, 2 });

            var result = sut.Last();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback());
        }

        [Fact]
        public void Last_List_Fails()
        {
            var sut = Result.Fail<List<int>>("fail");

            var result = sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Last_List_Fails_NotFound()
        {
            var sut = Result.Ok<List<int>>(new List<int>());

            var result = sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public void Last_List_Succeeds()
        {
            var sut = Result.Ok<List<int>>(new List<int>() { 1, 2 });

            var result = sut.Last();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback());
        }
    }
}
