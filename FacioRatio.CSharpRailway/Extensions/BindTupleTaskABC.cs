using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Result<D>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, D> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return (a, b, c, func(a, b, c)); });
        }

        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<Result<D>>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<D>> func)
        {
            return tTask.Bind(async y => { (A a, B b, C c) = y; return (a, b, c, await func(a, b, c)); });
        }
    }
}
