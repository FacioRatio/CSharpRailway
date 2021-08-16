using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
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
    }
}
