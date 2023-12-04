using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultFilterTExtensionsTests
    {
        [Fact]
        public void Filter_IEnumerable_Result_Succeeds()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Filter(item =>
            {
                return item == 1 ? Result.Ok(false) : Result.Ok(true);
            });

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.ValueOrFallback().Count);
            Assert.Equal(2, result.ValueOrFallback()[0]);
            Assert.Equal(3, result.ValueOrFallback()[1]);
        }

        [Fact]
        public async Task Filter_IEnumerable_TaskResult_Succeeds()
        {
            var items = new int[] { 1, 2, 3 };

            var result = await items.Filter(item =>
            {
                return item == 1 ? Result.OkTask(false) : Result.OkTask(true);
            });

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.ValueOrFallback().Count);
            Assert.Equal(2, result.ValueOrFallback()[0]);
            Assert.Equal(3, result.ValueOrFallback()[1]);
        }

        //!!test remaining extensions
    }
}
