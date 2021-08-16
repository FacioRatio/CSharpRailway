using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<Empty>> Combine(this Task<Result<Empty>> tTask, Result<Empty> u, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
            return t.Combine(u, aggregateFailure);
        }

        public static async Task<Result<Empty>> Combine(this Task<Result<Empty>> tTask, Task<Result<Empty>> uTask, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
            var u = await uTask;
            return t.Combine(u, aggregateFailure);
        }

        public static Task<Result<Empty>> Combine(this Task<Result<Empty>> t, Result<Empty> u)
        {
            return t.Combine(u, (te, ue) => new AggregateException(te, ue));
        }

        public static Task<Result<Empty>> Combine(this Task<Result<Empty>> tTask, Task<Result<Empty>> uTask)
        {
            return tTask.Combine(uTask, (te, ue) => new AggregateException(te, ue));
        }
    }
}
