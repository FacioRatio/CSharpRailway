using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskTExtensions
    {
        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Result<U>> func)
        {
            return (await tTask).Bind(func);
        }

        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Task<Result<U>>> func)
        {
            return await (await tTask).Bind(func);
        }

        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, U> func)
        {
            return (await tTask).Bind(func);
        }

        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Task<U>> func)
        {
            return await (await tTask).Bind(func);
        }
    }
}
