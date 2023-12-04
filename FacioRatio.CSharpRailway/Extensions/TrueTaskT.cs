using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTrueTaskTExtensions
    {
        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            return (await tTask).True(func, conditionMsg);
        }

        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            return await (await tTask).True(func, conditionMsg);
        }

        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, bool> func, string conditionMsg = null)
        {
            return (await tTask).True(func, conditionMsg);
        }

        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            return await (await tTask).True(func, conditionMsg);
        }
    }
}
