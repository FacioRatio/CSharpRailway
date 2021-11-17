using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultEachTaskTExtensionsTests
    {
        [Fact]
        public async Task Each_Action_Succeeds()
        {
            void f(int j)
            {
                return;
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task Each_ResultEmpty_Fails()
        {
            Result<Empty> f(int j)
            {
                return j == 0 ? Result.Ok() : Result.Fail("nope");
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
        }

        [Fact]
        public async Task Each_ResultEmpty_Succeeds()
        {
            Result<Empty> f(int j)
            {
                return j < 4 ? Result.Ok() : Result.Fail("nope");
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task Each_Task_Succeeds()
        {
            Task f(int j)
            {
                return Task.CompletedTask;
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task Each_TaskResultEmpty_Fails()
        {
            Task<Result<Empty>> f(int j)
            {
                return Task.FromResult(j == 0 ? Result.Ok() : Result.Fail("nope"));
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
        }

        [Fact]
        public async Task Each_TaskResultEmpty_Succeeds()
        {
            Task<Result<Empty>> f(int j)
            {
                return Task.FromResult(j < 4 ? Result.Ok() : Result.Fail("nope"));
            }
            var ints = Enumerable.Range(0, 3);

            {
                var result = await Task.FromResult(ints).Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await Task.FromResult(ints.ToList()).Each(f);
                Assert.True(result.IsSuccess);
            }
        }
    }
}
