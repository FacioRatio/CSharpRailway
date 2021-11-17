using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnFailureTaskTExtensions
    {
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Action<Exception> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                action(t.Error);
            }
            return t;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Task> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                await action(t.Error);
            }
            return t;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Result<T>> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                var f = action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Task<Result<T>>> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                var f = await action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }
    }
}
