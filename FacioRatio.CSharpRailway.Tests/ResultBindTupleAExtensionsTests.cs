using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTupleAExtensionsTests
    {
        [Fact]
        public void BindTuple_AResultB_Fails()
        {
            var sut = Result.Fail<string>("fail");

            var result = sut.BindTuple(s => Result.Ok(1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void BindTuple_AResultB_Succeeds()
        {
            var sut = Result.Ok("success");

            var result = sut.BindTuple(s => Result.Ok(1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal(("success", 1), result.ValueOrFallback());
        }

        [Fact]
        public void BindTuple_AB_Fails()
        {
            var sut = Result.Fail<string>("fail");

            var result = sut.BindTuple(s => 1);

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void BindTuple_AB_Succeeds()
        {
            var sut = Result.Ok("success");

            var result = sut.BindTuple(s => 1);

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal(("success", 1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ATaskResultB_Fails()
        {
            var sut = Result.Fail<string>("fail");

            var result = await sut.BindTuple(s => Task.FromResult(Result.Ok(1)));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ATaskResultB_Succeeds()
        {
            var sut = Result.Ok("success");

            var result = await sut.BindTuple(s => Task.FromResult(Result.Ok(1)));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal(("success", 1), result.ValueOrFallback());
        }

        [Fact]
        public async Task BindTuple_ATaskB_Fails()
        {
            var sut = Result.Fail<string>("fail");

            var result = await sut.BindTuple(s => Task.FromResult(1));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task BindTuple_ATaskB_Succeeds()
        {
            var sut = Result.Ok("success");

            var result = await sut.BindTuple(s => Task.FromResult(1));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<(string, int)>(result.ValueOrFallback());
            Assert.Equal(("success", 1), result.ValueOrFallback());
        }
    }
}
