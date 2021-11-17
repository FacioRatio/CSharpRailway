using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskABCsExtensions
    {
        public static async Task<Result<U>> Bind<A, B, C, U>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Result<U>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }

        public static async Task<Result<U>> Bind<A, B, C, U>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<Result<U>>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = await func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }
    }
}
