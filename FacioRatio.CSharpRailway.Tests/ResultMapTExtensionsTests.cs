using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultMapTExtensionsTests
    {
        [Fact]
        public void Map_IEnumerable_ResultU_Succeeds()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Map(item =>
            {
                return Result.Ok(item * 2);
            });

            Assert.True(result.IsSuccess);
            Assert.Equal(3, result.ValueOrFallback().Count);
            Assert.Equal(2, result.ValueOrFallback()[0]);
            Assert.Equal(4, result.ValueOrFallback()[1]);
            Assert.Equal(6, result.ValueOrFallback()[2]);
        }

        [Fact]
        public void Map_IEnumerable_ResultU_Fails()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Map(item =>
            {
                return item == 1
                    ? Result.Fail<int>("bad one")
                    : Result.Ok(item * 2);
            });

            Assert.False(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
            Assert.Equal("bad one", result.Error.Message);
        }

        [Fact]
        public void Map_IEnumerable_ResultU_Succeeds_IgnoresFailures()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Map(item =>
            {
                return item == 1
                    ? Result.Fail<int>("bad one")
                    : Result.Ok(item * 2);
            }, ignoreFails: true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.ValueOrFallback().Count);
            Assert.Equal(4, result.ValueOrFallback()[0]);
            Assert.Equal(6, result.ValueOrFallback()[1]);
        }

        [Fact]
        public async Task Map_IEnumerable_TaskResultU_Succeeds()
        {
            var items = new int[] { 1, 2, 3 };

            var result = await items.Map(item =>
            {
                return Task.FromResult(Result.Ok(item * 2));
            });

            Assert.True(result.IsSuccess);
            Assert.Equal(3, result.ValueOrFallback().Count);
            Assert.Equal(2, result.ValueOrFallback()[0]);
            Assert.Equal(4, result.ValueOrFallback()[1]);
            Assert.Equal(6, result.ValueOrFallback()[2]);
        }

        [Fact]
        public async Task Map_IEnumerable_TaskResultU_Fails()
        {
            var items = new int[] { 1, 2, 3 };

            var result = await items.Map(item =>
            {
                return item == 1
                    ? Task.FromResult(Result.Fail<int>("bad one"))
                    : Task.FromResult(Result.Ok(item * 2));
            });

            Assert.False(result.IsSuccess);
            Assert.Null(result.ValueOrFallback());
            Assert.Equal("bad one", result.Error.Message);
        }

        [Fact]
        public async Task Map_IEnumerable_TaskResultU_Succeeds_IgnoresFailures()
        {
            var items = new int[] { 1, 2, 3 };

            var result = await items.Map(item =>
            {
                return item == 1
                    ? Task.FromResult(Result.Fail<int>("bad one"))
                    : Task.FromResult(Result.Ok(item * 2));
            }, ignoreFails: true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.ValueOrFallback().Count);
            Assert.Equal(4, result.ValueOrFallback()[0]);
            Assert.Equal(6, result.ValueOrFallback()[1]);
        }

        [Fact]
        public void Map_ResultIEnumerable_ResultU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1));

            var result = items.Map(item =>
            {
                return Result.Ok(item * 2);
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public async Task Map_ResultIEnumerable_TaskResultU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1));

            var result = await items.Map(item =>
            {
                return Task.FromResult(Result.Ok(item * 2));
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public void Map_ResultIEnumerable_U_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1));

            var result = items.Map(item =>
            {
                return item * 2;
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public async Task Map_ResultIEnumerable_TaskU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1));

            var result = await items.Map(item =>
            {
                return Task.FromResult(item * 2);
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public void Map_ResultList_ResultU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1).ToList());

            var result = items.Map(item =>
            {
                return Result.Ok(item * 2);
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public async Task Map_ResultList_TaskResultU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1).ToList());

            var result = await items.Map(item =>
            {
                return Task.FromResult(Result.Ok(item * 2));
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public void Map_ResultList_U_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1).ToList());

            var result = items.Map(item =>
            {
                return item * 2;
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }

        [Fact]
        public async Task Map_ResultList_TaskU_Works()
        {
            var items = Result.Ok(Enumerable.Range(1, 1).ToList());

            var result = await items.Map(item =>
            {
                return Task.FromResult(item * 2);
            });

            Assert.True(result.IsSuccess);
            Assert.Single(result.ValueOrFallback());
            Assert.Equal(2, result.ValueOrFallback()[0]);
        }
    }
}
