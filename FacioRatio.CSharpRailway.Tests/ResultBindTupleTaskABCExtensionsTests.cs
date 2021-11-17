using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTupleTaskABCExtensionsTests
    {
        [Fact]
        public async Task BindTuple_ABCResultD_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.BindTuple((s, i, h) => Result.Ok((long)1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCResultD_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1)));

            var result = await sut.BindTuple((s, i, h) => Result.Ok((long)1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCD_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.BindTuple((s, i, h) => (long)1);

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCD_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1)));

            var result = await sut.BindTuple((s, i, h) => (long)1);

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCTaskResultD_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.BindTuple((s, i, h) => Task.FromResult(Result.Ok((long)1)));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCTaskResultD_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1)));

            var result = await sut.BindTuple((s, i, h) => Task.FromResult(Result.Ok((long)1)));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCTaskD_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.BindTuple((s, i, h) => Task.FromResult((long)1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCTaskD_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1)));

            var result = await sut.BindTuple((s, i, h) => Task.FromResult((long)1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1), result.ValueOrFallback());
        }
    }
}
