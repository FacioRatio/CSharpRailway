using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
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
