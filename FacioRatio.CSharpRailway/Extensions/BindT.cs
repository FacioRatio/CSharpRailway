using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<U> Bind<T, U>(this Result<T> t, Func<T, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return func(t.Value);
        }

        public static Task<Result<U>> Bind<T, U>(this Result<T> t, Func<T, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            return func(t.Value);
        }

        public static Result<U> Bind<T, U>(this Result<T> t, Func<T, U> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return Result.Ok(func(t.Value));
        }

        public static async Task<Result<U>> Bind<T, U>(this Result<T> t, Func<T, Task<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return Result.Ok(await func(t.Value));
        }
    }
}
