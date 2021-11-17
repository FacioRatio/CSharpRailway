using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskABExtensions
    {
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Result<C>> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, C> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return (a, b, func(a, b)); });
        }

        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Task<Result<C>>> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Task<C>> func)
        {
            return tTask.Bind(async y => { (A a, B b) = y; return (a, b, await func(a, b)); });
        }
    }
}
