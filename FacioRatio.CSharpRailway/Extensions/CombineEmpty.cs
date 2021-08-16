using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<Empty> Combine(this Result<Empty> t, Result<Empty> u, Func<Exception, Exception, Exception> aggregateFailure)
        {
            return t.Combine(u, (u, v) => new Empty(), aggregateFailure);
        }

        public static Result<Empty> Combine(this Result<Empty> t, Result<Empty> u)
        {
            return t.Combine(u, (te, ue) => new AggregateException(te, ue));
        }

        public static async Task<Result<Empty>> Combine(this Result<Empty> t, Task<Result<Empty>> uTask, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var u = await uTask;
            return t.Combine(u, aggregateFailure);
        }

        public static Task<Result<Empty>> Combine(this Result<Empty> t, Task<Result<Empty>> uTask)
        {
            return t.Combine(uTask, (te, ue) => new AggregateException(te, ue));
        }
    }
}
