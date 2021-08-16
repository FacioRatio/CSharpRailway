using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>($"{typeof(T).Name} collection is not empty.");

            return Result.Ok();
        }

        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>($"{typeof(T).Name} collection is not empty.");

            return Result.Ok();
        }
    }
}
