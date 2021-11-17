using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultCombineTaskTExtensions
    {
        public static async Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Result<U> u, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
            return t.Combine(u, aggregateSuccess, aggregateFailure);
        }

        public static async Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
            var u = await uTask;
            return t.Combine(u, aggregateSuccess, aggregateFailure);
        }

        public static Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> t, Result<U> u, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(u, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }

        public static Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess)
        {
            return tTask.Combine(uTask, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }
    }
}
