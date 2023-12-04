using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFalseTaskTExtensions
    {
        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            return (await tTask).False(func, conditionMsg);
        }

        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            return await (await tTask).False(func, conditionMsg);
        }

        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, bool> func, string conditionMsg = null)
        {
            return (await tTask).False(func, conditionMsg);
        }

        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            return await (await tTask).False(func, conditionMsg);
        }
    }
}
