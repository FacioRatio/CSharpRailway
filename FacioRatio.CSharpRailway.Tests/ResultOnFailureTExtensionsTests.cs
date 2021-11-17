using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultOnFailureTExtensionsTests
    {
        [Fact]
        public void OnFailure_ActionException_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = sut.OnFailure(e => i = 1);
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public void OnFailure_ActionException_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = sut.OnFailure(e => i = 1);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
            Assert.Equal(1, i);
        }

        [Fact]
        public async Task OnFailure_FuncExceptionTask_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = await sut.OnFailure(e => Task.FromResult(i = 1));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task OnFailure_FuncExceptionTask_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = await sut.OnFailure(e => Task.FromResult(i = 1));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
            Assert.Equal(1, i);
        }

        [Fact]
        public void OnFailure_FuncExceptionResultT_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = sut.OnFailure(e => Result.Ok(i = 1));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public void OnFailure_FuncExceptionResultT_Failure_Success()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = sut.OnFailure(e => Result.Ok(i = 1));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
            Assert.Equal(1, i);
        }

        [Fact]
        public void OnFailure_FuncExceptionResultT_Failure_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = sut.OnFailure(e => Result.Fail<int>("more"));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Contains("fail", result.Error.Message);
            Assert.Contains("more", result.Error.Message);
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task OnFailure_FuncExceptionTaskResultT_Success()
        {
            var sut = Result.Ok<int>(1);

            var i = 0;
            var result = await sut.OnFailure(e => Task.FromResult(Result.Ok(i = 1)));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task OnFailure_FuncExceptionTaskResultT_Failure_Success()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = await sut.OnFailure(e => Task.FromResult(Result.Ok(i = 1)));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
            Assert.Equal(1, i);
        }

        [Fact]
        public async Task OnFailure_FuncExceptionTaskResultT_Failure_Failure()
        {
            var sut = Result.Fail<int>("fail");

            var i = 0;
            var result = await sut.OnFailure(e => Task.FromResult(Result.Fail<int>("more")));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Contains("fail", result.Error.Message);
            Assert.Contains("more", result.Error.Message);
            Assert.Equal(0, i);
        }
    }
}
