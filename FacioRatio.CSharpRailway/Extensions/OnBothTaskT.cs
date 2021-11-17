using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnBothTaskTExtensions
    {
        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Action<Result<T>> action)
        {
            var t = await tTask;
            action(t);
            return t;
        }

        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Action<Task<Result<T>>> action)
        {
            var t = await tTask;
            action(Task.FromResult(t));
            return t;
        }

        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Func<Result<T>, Task> action)
        {
            var t = await tTask;
            await action(t);
            return t;
        }

        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Func<Task<Result<T>>, Task> action)
        {
            var t = await tTask;
            await action(Task.FromResult(t));
            return t;
        }
    }
}
