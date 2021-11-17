using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultLastTaskTExtensionsTests
    {
        [Fact]
        public async Task Last_IEnumerable_Fails()
        {
            var sut = Task.FromResult(Result.Fail<IEnumerable<int>>("fail"));

            var result = await sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Last_IEnumerable_Fails_NotFound()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>()));

            var result = await sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public async Task Last_IEnumerable_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<IEnumerable<int>>(new List<int>() { 1, 2 }));

            var result = await sut.Last();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback());
        }

        [Fact]
        public async Task Last_List_Fails()
        {
            var sut = Task.FromResult(Result.Fail<List<int>>("fail"));

            var result = await sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Last_List_Fails_NotFound()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>()));

            var result = await sut.Last();

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.IsType<NotFoundException>(result.Error);
            Assert.Equal("Int32 collection is empty.", result.Error.Message);
        }

        [Fact]
        public async Task Last_List_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok<List<int>>(new List<int>() { 1, 2 }));

            var result = await sut.Last();

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback());
        }
    }
}
