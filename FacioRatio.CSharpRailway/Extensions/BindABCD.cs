using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindABCDExtensions
    {
        public static Result<U> Bind<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4);
            return result;
        }

        public static Task<Result<U>> Bind<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3, t.Value.Item4);
            return result;
        }
    }
}
