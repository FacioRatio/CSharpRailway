using System.Collections.Generic;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultFirstOrDefaultTExtensionsTests
    {
        [Fact]
        public void FirstOrDefault_IEnumerable_Fails()
        {
            var sut = Result.Fail<IEnumerable<int>>("fail");

            var result = sut.FirstOrDefault();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void FirstOrDefault_IEnumerable_Default()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>());

            var result = sut.FirstOrDefault();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(default, result.ValueOrFallback());
        }

        [Fact]
        public void FirstOrDefault_IEnumerable_Succeeds()
        {
            var sut = Result.Ok<IEnumerable<int>>(new List<int>() { 1 });

            var result = sut.FirstOrDefault();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(1, result.ValueOrFallback());
        }

        [Fact]
        public void FirstOrDefault_List_Fails()
        {
            var sut = Result.Fail<List<int>>("fail");

            var result = sut.FirstOrDefault();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void FirstOrDefault_List_Default()
        {
            var sut = Result.Ok<List<int>>(new List<int>());

            var result = sut.FirstOrDefault();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(default, result.ValueOrFallback());
        }

        [Fact]
        public void FirstOrDefault_List_Succeeds()
        {
            var sut = Result.Ok<List<int>>(new List<int>() { 1 });

            var result = sut.FirstOrDefault();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(1, result.ValueOrFallback());
        }
    }
}
