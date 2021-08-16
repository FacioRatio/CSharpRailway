using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<V> Combine<T, U, V>(this Result<T> t, Result<U> u, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            if (t.IsFailure && u.IsFailure)
                return Result.Fail<V>(aggregateFailure(t.Error, u.Error));

            if (t.IsFailure)
                return Result.Fail<V>(t.Error);

            if (u.IsFailure)
                return Result.Fail<V>(u.Error);

            return Result.Ok(aggregateSuccess(t.Value, u.Value));
        }

        public static async Task<Result<V>> Combine<T, U, V>(this Result<T> t, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var u = await uTask;
            return t.Combine(u, aggregateSuccess, aggregateFailure);
        }

        public static Result<V> Combine<T, U, V>(this Result<T> t, Result<U> u, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(u, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }

        public static Task<Result<V>> Combine<T, U, V>(this Result<T> t, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(uTask, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }
    }
}
