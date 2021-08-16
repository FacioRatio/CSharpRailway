using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<(A, B, C)> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Result<C>> func)
        {
            return t.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        public static Result<(A, B, C)> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, C> func)
        {
            return t.Bind(y => { (A a, B b) = y; return (a, b, func(a, b)); });
        }

        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Task<Result<C>>> func)
        {
            return t.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Task<C>> func)
        {
            return t.Bind(async y => { (A a, B b) = y; var c = await func(a, b); return (a, b, c); });
        }
    }
}
