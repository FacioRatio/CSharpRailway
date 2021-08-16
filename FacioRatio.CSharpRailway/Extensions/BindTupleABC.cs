using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<(A, B, C, D)> BindTuple<A, B, C, D>(this Result<(A, B, C)> t, Func<A, B, C, Result<D>> func)
        {
            return t.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        public static Result<(A, B, C, D)> BindTuple<A, B, C, D>(this Result<(A, B, C)> t, Func<A, B, C, D> func)
        {
            return t.Bind(y => { (A a, B b, C c) = y; return (a, b, c, func(a, b, c)); });
        }

        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Result<(A, B, C)> t, Func<A, B, C, Task<Result<D>>> func)
        {
            return t.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Result<(A, B, C)> t, Func<A, B, C, Task<D>> func)
        {
            return t.Bind(async y => { (A a, B b, C c) = y; var d = await func(a, b, c); return (a, b, c, d); });
        }
    }
}
