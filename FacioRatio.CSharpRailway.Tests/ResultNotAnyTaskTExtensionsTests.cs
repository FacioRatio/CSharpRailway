using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultNotAnyTaskTExtensionsTests
    {
        [Fact]
        public async Task NotAny_TaskResultIEnumerable_Fails()
        {
            var sut = Task.FromResult(Result.Fail<IEnumerable<int>>("fail"));

            var result = await sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task NotAny_TaskResultIEnumerable_Fails_NotEmpty()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>() { 1 }));

            var result = await sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.IsType<NotEmptyException>(result.Error);
            Assert.Equal("Int32 collection is not empty.", result.Error.Message);
        }

        [Fact]
        public async Task NotAny_TaskResultIEnumerable_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>()));

            var result = await sut.NotAny();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback(new Empty()));
        }

        [Fact]
        public async Task NotAny_TaskResultList_Fails()
        {
            var sut = Task.FromResult(Result.Fail<List<int>>("fail"));

            var result = await sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task NotAny_TaskResultList_Fails_NotEmpty()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>() { 1 }));

            var result = await sut.NotAny();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<Empty>(result.ValueOrFallback(new Empty()));
            Assert.IsType<NotEmptyException>(result.Error);
            Assert.Equal("Int32 collection is not empty.", result.Error.Message);
        }

        [Fact]
        public async Task NotAny_TaskResultList_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>()));

            var result = await sut.NotAny();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback(new Empty()));
        }
    }
}
