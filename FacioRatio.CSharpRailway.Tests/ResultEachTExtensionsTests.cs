using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultEachTExtensionsTests
    {
        [Fact]
        public void Each_Action_Succeeds()
        {
            void f(int j)
            {
                return;
            }
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = ints.Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = ints.ToList().Each(f);
                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public void Each_ResultEmpty_Fails()
        {
            Result<Empty> f(int j)
            {
                return j == 0 ? Result.Ok() : Result.Fail("nope");
            }
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = ints.Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
            {
                var result = ints.ToList().Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
        }

        [Fact]
        public void Each_ResultEmpty_Succeeds()
        {
            Result<Empty> f(int j)
            {
                return j < 4 ? Result.Ok() : Result.Fail("nope");
            }
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = ints.Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = ints.ToList().Each(f);
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
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = await ints.Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await ints.ToList().Each(f);
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
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = await ints.Each(f);
                Assert.False(result.IsSuccess);
                var error = result.Error as AggregateException;
                Assert.Equal(2, error.InnerExceptions.Count);
                Assert.Equal("nope", error.InnerExceptions[0].Message);
                Assert.Equal("nope", error.InnerExceptions[1].Message);
            }
            {
                var result = await ints.ToList().Each(f);
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
            var ints = new int[3] { 0, 1, 2 };

            {
                var result = await ints.Each(f);
                Assert.True(result.IsSuccess);
            }
            {
                var result = await ints.ToList().Each(f);
                Assert.True(result.IsSuccess);
            }
        }
    }
}
