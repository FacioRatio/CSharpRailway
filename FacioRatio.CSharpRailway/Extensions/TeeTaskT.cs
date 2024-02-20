using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskTExtensions
    {
        public static async Task<Result<T>> Tee<T>(this Task<Result<T>> tTask, Action<T> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                func(t.Value);

            return t;
        }

        public static async Task<Result<T>> Tee<T>(this Task<Result<T>> tTask, Func<T, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                await func(t.Value);

            return t;
        }

        public static async Task<Result<T>> Tee<T>(this Task<Result<T>> tTask, Func<T, Result<Empty>> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                return func(t.Value).Bind(x => t);

            return t;
        }

        public static async Task<Result<T>> Tee<T>(this Task<Result<T>> tTask, Func<T, Task<Result<Empty>>> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                return await func(t.Value).Bind(x => t);

            return t;
        }
    }
}
