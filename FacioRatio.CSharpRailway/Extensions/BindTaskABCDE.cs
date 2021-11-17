using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskABCDEExtensions
    {
        public static async Task<Result<U>> Bind<A, B, C, D, E, U>(this Task<Result<(A, B, C, D, E)>> tTask, Func<A, B, C, D, E, Result<U>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4, t.Value.Item5);
            return result;
        }

        public static async Task<Result<U>> Bind<A, B, C, D, E, U>(this Task<Result<(A, B, C, D, E)>> tTask, Func<A, B, C, D, E, Task<Result<U>>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = await func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4, t.Value.Item5);
            return result;
        }
    }
}
