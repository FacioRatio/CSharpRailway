using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstOrDefaultTaskTExtensions
    {
        public static async Task<Result<T>> FirstOrDefault<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            return Result.Ok(value);
        }

        public static async Task<Result<T>> FirstOrDefault<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Ok<T>(default);

            return Result.Ok(t.Value[0]);
        }
    }
}
