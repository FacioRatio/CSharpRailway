using System;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultCombineTaskExtensionsTests
    {
        [Fact]
        public async Task Combine_Fails_1()
        {
            var r1 = Task.FromResult(Result.Ok());
            var r2 = Result.Fail("test2");
            var r3 = Task.FromResult(Result.Fail("test3"));
            var sut = await r1.Combine(r2).Combine(r3);

            Assert.False(sut.IsSuccess);
            var error = sut.Error as AggregateException;
            Assert.Equal(2, error.InnerExceptions.Count);
            Assert.Equal("test2", error.InnerExceptions[0].Message);
            Assert.Equal("test3", error.InnerExceptions[1].Message);
            Assert.Equal("One or more errors occurred. (test2) (test3)", error.Message);
        }

        [Fact]
        public async Task Combine_Fails_2()
        {
            var r1 = Task.FromResult(Result.Fail("test1"));
            var r2 = Result.Ok();
            var r3 = Task.FromResult(Result.Fail("test3"));
            var sut = await r1.Combine(r2).Combine(r3);

            Assert.False(sut.IsSuccess);
            var error = sut.Error as AggregateException;
            Assert.Equal(2, error.InnerExceptions.Count);
            Assert.Equal("test1", error.InnerExceptions[0].Message);
            Assert.Equal("test3", error.InnerExceptions[1].Message);
            Assert.Equal("One or more errors occurred. (test1) (test3)", error.Message);
        }

        [Fact]
        public async Task Combine_Succeeds()
        {
            var r1 = Task.FromResult(Result.Ok("test1"));
            var r2 = Result.Ok("test2");
            var r3 = Task.FromResult(Result.Ok("test3"));
            var sut = await r1.Combine(r2, (a, b) => $"{a} {b}").Combine(r3, (a, b) => $"{a} {b}");

            Assert.True(sut.IsSuccess);
            Assert.Equal("test1 test2 test3", sut.ValueOrFallback());
        }
    }
}
