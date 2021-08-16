using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<(A, B)> BindTuple<A, B>(this Result<A> t, Func<A, Result<B>> func)
        {
            return t.Bind(a => func(a).Bind(b => (a, b)));
        }

        public static Result<(A, B)> BindTuple<A, B>(this Result<A> t, Func<A, B> func)
        {
            return t.Bind(a => (a, func(a)));
        }

        public static Task<Result<(A, B)>> BindTuple<A, B>(this Result<A> t, Func<A, Task<Result<B>>> func)
        {
            return t.Bind(a => func(a).Bind(b => (a, b)));
        }

        public static Task<Result<(A, B)>> BindTuple<A, B>(this Result<A> t, Func<A, Task<B>> func)
        {
            return t.Bind(async a => (a, await func(a)));
        }
    }
}
