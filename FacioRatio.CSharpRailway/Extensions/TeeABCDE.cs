using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABCDEExtensions
    {
        public static Result<(A, B, C, D, E)> Tee<A, B, C, D, E>(this Result<(A, B, C, D, E)> t, Action<A, B, C, D, E> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                func(a, b, c, d, e);
            }
            return t;
        }

        public static async Task<Result<(A, B, C, D, E)>> Tee<A, B, C, D, E>(this Result<(A, B, C, D, E)> t, Func<A, B, C, D, E, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                await func(a, b, c, d, e);
            }
            return t;
        }
    }
}
