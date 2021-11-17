using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindABCDEExtensions
    {
        public static Result<U> Bind<A, B, C, D, E, U>(this Result<(A, B, C, D, E)> t, Func<A, B, C, D, E, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4, t.Value.Item5);
            return result;
        }

        public static Task<Result<U>> Bind<A, B, C, D, E, U>(this Result<(A, B, C, D, E)> t, Func<A, B, C, D, E, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4, t.Value.Item5);
            return result;
        }
    }
}
