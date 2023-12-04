using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultReduceTExtensionsTests
    {
        //!!add tests

        [Fact]
        public void Reduce_IEnumerable_ResultU_Succeeds()
        {
            var items = new int[] { 1, 2, 3 };

            var result = items.Reduce((item, acc) =>
            {
                return Result.Ok(acc + item);
            }, 1);

            Assert.True(result.IsSuccess);
            Assert.Equal(7, result.ValueOrFallback());
        }
    }
}
