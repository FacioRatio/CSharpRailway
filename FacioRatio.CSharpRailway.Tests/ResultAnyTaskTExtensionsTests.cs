using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultAnyTaskTExtensionsTests
    {
        [Fact]
        public async Task Any_TaskResultIEnumerable_Fails()
        {
            var sut = Task.FromResult(Result.Fail<IEnumerable<int>>("fail"));

            var result = await sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<IEnumerable<int>>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Any_TaskResultIEnumerable_Fails_Empty()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>()));

            var result = await sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<IEnumerable<int>>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public async Task Any_TaskResultIEnumerable_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>() { 1 }));

            var result = await sut.Any();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
        }

        [Fact]
        public async Task Any_TaskResultList_Fails()
        {
            var sut = Task.FromResult(Result.Fail<List<int>>("fail"));

            var result = await sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<List<int>>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Any_TaskResultList_Fails_Empty()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>()));

            var result = await sut.Any();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<List<int>>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public async Task Any_TaskResultList_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>() { 1 }));

            var result = await sut.Any();

            Assert.True(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
        }
    }
}
