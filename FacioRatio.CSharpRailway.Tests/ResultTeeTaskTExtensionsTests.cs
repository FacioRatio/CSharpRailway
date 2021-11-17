using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTeeTaskTExtensionsTests
    {
        [Fact]
        public async Task Tee_Action_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.Tee(x => i = x * 2);
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public async Task Tee_Action_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.Tee(x => i = x * 2);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, i);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Tee_FuncTask_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.Tee(x => Task.FromResult(i = x * 2));
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.Tee(x => Task.FromResult(i = x * 2));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, i);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Tee_FuncResultEmpty_Success_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.Tee(x => { i = x * 2; return Result.Ok(); });
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public async Task Tee_FuncResultEmpty_Success_Failure()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var result = await sut.Tee(x => Result.Fail("fail"));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Tee_FuncResultEmpty_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.Tee(x => Result.Fail("more"));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, i);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Tee_FuncTaskResultEmpty_Success_Success()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var i = 0;
            var result = await sut.Tee(x => { i = x * 2; return Task.FromResult(Result.Ok()); });
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public async Task Tee_FuncTaskResultEmpty_Success_Failure()
        {
            var sut = Task.FromResult(Result.Ok<int>(1));

            var result = await sut.Tee(x => Task.FromResult(Result.Fail("fail")));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, result.ValueOrFallback());
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Tee_FuncTaskResultEmpty_Failure()
        {
            var sut = Task.FromResult(Result.Fail<int>("fail"));

            var i = 0;
            var result = await sut.Tee(x => Task.FromResult(Result.Fail("more")));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<int>(result.ValueOrFallback());
            Assert.Equal(0, i);
            Assert.Equal("fail", result.Error.Message);
        }
    }
}
