using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskABExtensions
    {
        public static async Task<Result<U>> Bind<A, B, U>(this Task<Result<(A, B)>> tTask, Func<A, B, Result<U>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2);
            return result;
        }

        public static async Task<Result<U>> Bind<A, B, U>(this Task<Result<(A, B)>> tTask, Func<A, B, Task<Result<U>>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = await func(t.Value.Item1, t.Value.Item2);
            return result;
        }
    }
}
