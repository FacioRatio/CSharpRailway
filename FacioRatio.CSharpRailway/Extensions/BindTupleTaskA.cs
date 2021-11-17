using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskAExtensions
    {
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Result<B>> func)
        {
            return tTask.Bind(a => func(a).Bind(b => (a, b)));
        }

        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, B> func)
        {
            return tTask.Bind(a => (a, func(a)));
        }

        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Task<Result<B>>> func)
        {
            return tTask.Bind(a => func(a).Bind(b => (a, b)));
        }

        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Task<B>> func)
        {
            return tTask.Bind(async a => (a, await func(a)));
        }
    }
}
