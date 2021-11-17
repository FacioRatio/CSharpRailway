using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTExtensions
    {
        public static Result<T> Tee<T>(this Result<T> t, Action<T> func)
        {
            if (t.IsSuccess)
                func(t.Value);

            return t;
        }

        public static Task<Result<T>> Tee<T>(this Result<T> t, Func<T, Task> func)
        {
            if (t.IsSuccess)
                func(t.Value);

            return Task.FromResult(t);
        }

        public static Result<T> Tee<T>(this Result<T> t, Func<T, Result<Empty>> func)
        {
            if (t.IsSuccess)
                return func(t.Value).Bind(_ => t);

            return t;
        }

        public static Task<Result<T>> Tee<T>(this Result<T> t, Func<T, Task<Result<Empty>>> func)
        {
            if (t.IsSuccess)
                return func(t.Value).Bind(_ => t);

            return Task.FromResult(t);
        }
    }
}
