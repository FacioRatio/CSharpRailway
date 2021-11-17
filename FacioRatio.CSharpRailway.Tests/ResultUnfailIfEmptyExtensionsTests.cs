using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultUnfailIfEmptyExtensionsTests
    {
        [Fact]
        public void UnFailIf_FuncExceptionbool_Success()
        {
            var sut = Result.Ok();

            var result = sut.UnFailIf(e => e is NotEmptyException);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void UnFailIf_FuncExceptionbool_Failure_Success()
        {
            var sut = Result.Fail(new NotEmptyException("fail"));

            var result = sut.UnFailIf(e => e is NotEmptyException);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void UnFailIf_FuncExceptionbool_Failure_Failure()
        {
            var sut = Result.Fail(new NotFoundException("fail"));

            var result = sut.UnFailIf(e => e is NotEmptyException);
            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task UnFailIf_FuncExceptionTaskbool_Success()
        {
            var sut = Result.Ok();

            var result = await sut.UnFailIf(e => Task.FromResult(e is NotEmptyException));
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UnFailIf_FuncExceptionTaskbool_Failure_Success()
        {
            var sut = Result.Fail(new NotEmptyException("fail"));

            var result = await sut.UnFailIf(e => Task.FromResult(e is NotEmptyException));
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UnFailIf_FuncExceptionTaskbool_Failure_Failure()
        {
            var sut = Result.Fail(new NotFoundException("fail"));

            var result = await sut.UnFailIf(e => Task.FromResult(e is NotEmptyException));
            Assert.True(result.IsFailure);
        }
    }
}
