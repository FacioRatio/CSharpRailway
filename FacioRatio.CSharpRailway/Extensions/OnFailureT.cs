using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnFailureTExtensions
    {
        public static Result<T> OnFailure<T>(this Result<T> t, Action<Exception> action)
        {
            if (t.IsFailure)
            {
                action(t.Error);
            }
            return t;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> t, Func<Exception, Task> action)
        {
            if (t.IsFailure)
            {
                await action(t.Error);
            }
            return t;
        }

        public static Result<T> OnFailure<T>(this Result<T> t, Func<Exception, Result<T>> action)
        {
            if (t.IsFailure)
            {
                var f = action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> t, Func<Exception, Task<Result<T>>> action)
        {
            if (t.IsFailure)
            {
                var f = await action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }
    }
}
