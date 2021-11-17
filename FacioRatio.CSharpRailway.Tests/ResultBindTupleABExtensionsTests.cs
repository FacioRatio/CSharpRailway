using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTupleABExtensionsTests
    {
        [Fact]
        public void BindTuple_ABResultC_Fails()
        {
            var sut = Result.Fail<(string, int)>("fail");

            var result = sut.BindTuple((s, i) => Result.Ok((short)1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void BindTuple_ABResultC_Succeeds()
        {
            var sut = Result.Ok(("success", 1));

            var result = sut.BindTuple((s, i) => Result.Ok((short)1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1), result.ValueOrFallback());
        }

        [Fact]
        public void BindTuple_ABC_Fails()
        {
            var sut = Result.Fail<(string, int)>("fail");

            var result = sut.BindTuple((s, i) => (short)1);

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void BindTuple_ABC_Succeeds()
        {
            var sut = Result.Ok(("success", 1));

            var result = sut.BindTuple((s, i) => (short)1);

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABTaskResultC_Fails()
        {
            var sut = Result.Fail<(string, int)>("fail");

            var result = await sut.BindTuple((s, i) => Task.FromResult(Result.Ok((short)1)));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABTaskResultC_Succeeds()
        {
            var sut = Result.Ok(("success", 1));

            var result = await sut.BindTuple((s, i) => Task.FromResult(Result.Ok((short)1)));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ABTaskC_Fails()
        {
            var sut = Result.Fail<(string, int)>("fail");

            var result = await sut.BindTuple((s, i) => Task.FromResult((short)1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ABTaskC_Succeeds()
        {
            var sut = Result.Ok(("success", 1));

            var result = await sut.BindTuple((s, i) => Task.FromResult((short)1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int, short)>(result.ValueOrFallback());
            Assert.Equal(("success", 1, (short)1), result.ValueOrFallback());
        }
    }
}
