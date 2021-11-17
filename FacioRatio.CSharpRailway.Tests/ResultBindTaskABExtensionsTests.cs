using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTaskABExtensionsTests
    {
        [Fact]
        public async Task Bind_ResultU_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int)>("fail"));

            var result = await sut.Bind((s, i) => Result.Ok($"{s}{i}"));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Bind_ResultU_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1)));

            var result = await sut.Bind((s, i) => Result.Ok($"{s}{i}"));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success1", result.ValueOrFallback());
        }

        [Fact]
        public async Task Bind_TaskResultU_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int)>("fail"));

            var result = await sut.Bind((s, i) => Task.FromResult(Result.Ok($"{s}{i}")));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Bind_TaskResultU_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1)));

            var result = await sut.Bind((s, i) => Task.FromResult(Result.Ok($"{s}{i}")));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success1", result.ValueOrFallback());
        }
    }
}
