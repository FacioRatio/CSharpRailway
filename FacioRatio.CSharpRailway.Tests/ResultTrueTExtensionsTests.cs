using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTrueTExtensionsTests
    {
        [Fact]
        public void True_ResultT_Fails()
        {
            var sut = Result.Fail<int>("fail");

            var result = sut.True(i => Result.Ok(true), "unseen fail");

            Assert.True(result.IsFailure);
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void True_ResultT_Succeeds_Condition()
        {
            var sut = Result.Ok(1);

            var result = sut.True(i => i == 1, "unseen fail");

            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.ValueOrFallback());
        }

        [Fact]
        public void True_ResultT_Fails_Condition()
        {
            var sut = Result.Ok(1);

            var result = sut.True(i => i == 2, "fail");

            Assert.False(result.IsSuccess);
            Assert.Equal("fail", result.Error.Message);
        }

        //[Fact]
        //public async Task Bind_TaskResultU_Fails()
        //{
        //    var sut = Result.Fail<int>("fail");

        //    var result = await sut.Bind(i => Task.FromResult(Result.Ok($"{i}")));

        //    Assert.True(result.IsFailure);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("fail", result.Error.Message);
        //}

        //[Fact]
        //public async Task Bind_TaskResultU_Succeeds()
        //{
        //    var sut = Result.Ok(1);

        //    var result = await sut.Bind(i => Task.FromResult(Result.Ok($"{i}")));

        //    Assert.True(result.IsSuccess);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("1", result.ValueOrFallback());
        //}

        //[Fact]
        //public void Bind_U_Fails()
        //{
        //    var sut = Result.Fail<int>("fail");

        //    var result = sut.Bind(i => $"{i}");

        //    Assert.True(result.IsFailure);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("fail", result.Error.Message);
        //}

        //[Fact]
        //public void Bind_U_Succeeds()
        //{
        //    var sut = Result.Ok(1);

        //    var result = sut.Bind(i => $"{i}");

        //    Assert.True(result.IsSuccess);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("1", result.ValueOrFallback());
        //}

        //[Fact]
        //public async Task Bind_TaskU_Fails()
        //{
        //    var sut = Result.Fail<int>("fail");

        //    var result = await sut.Bind(i => Task.FromResult($"{i}"));

        //    Assert.True(result.IsFailure);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("fail", result.Error.Message);
        //}

        //[Fact]
        //public async Task Bind_TaskU_Succeeds()
        //{
        //    var sut = Result.Ok(1);

        //    var result = await sut.Bind(i => Task.FromResult($"{i}"));

        //    Assert.True(result.IsSuccess);
        //    Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
        //    Assert.Equal("1", result.ValueOrFallback());
        //}
    }
}
