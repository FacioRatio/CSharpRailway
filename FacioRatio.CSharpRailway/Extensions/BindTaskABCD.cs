using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<U>> Bind<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, Result<U>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4);
            return result;
        }

        public static async Task<Result<U>> Bind<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, Task<Result<U>>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = await func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4);
            return result;
        }
    }
}
