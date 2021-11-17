using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultNotAnyTaskTExtensions
    {
        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }

        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Count > 0)
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }
    }
}
