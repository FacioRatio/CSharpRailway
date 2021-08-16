using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<U> Bind<A, B, U>(this Result<(A, B)> t, Func<A, B, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2);
            return result;
        }

        public static Task<Result<U>> Bind<A, B, U>(this Result<(A, B)> t, Func<A, B, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            var result = func(t.Value.Item1, t.Value.Item2);
            return result;
        }
    }
}
