using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTupleTaskABCDExtensionsTests
    {
        [Fact]
        public async Task BindTuple_ABCDResultE_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short, long)>("fail"));

            var result = await sut.BindTuple((s, i, h, l) => Result.Ok('!'));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCDResultE_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1, (long)1)));

            var result = await sut.BindTuple((s, i, h, l) => Result.Ok('!'));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1, '!'), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCDE_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short, long)>("fail"));

            var result = await sut.BindTuple((s, i, h, l) => '!');

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCDE_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1, (long)1)));

            var result = await sut.BindTuple((s, i, h, l) => '!');

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1, '!'), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCDTaskResultE_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short, long)>("fail"));

            var result = await sut.BindTuple((s, i, h, l) => Task.FromResult(Result.Ok('!')));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCDTaskResultE_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1, (long)1)));

            var result = await sut.BindTuple((s, i, h, l) => Task.FromResult(Result.Ok('!')));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1, '!'), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABCDTaskE_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short, long)>("fail"));

            var result = await sut.BindTuple((s, i, h, l) => Task.FromResult('!'));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABCDTaskE_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)1, (long)1)));

            var result = await sut.BindTuple((s, i, h, l) => Task.FromResult('!'));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short, long, char)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1, (long)1, '!'), result.ValueOrFallback());
        }
    }
}
