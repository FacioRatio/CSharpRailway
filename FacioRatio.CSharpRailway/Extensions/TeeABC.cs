using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABCExtensions
    {
        public static Result<(A, B, C)> Tee<A, B, C>(this Result<(A, B, C)> t, Action<A, B, C> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                func(a, b, c);
            }
            return t;
        }

        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Result<(A, B, C)> t, Func<A, B, C, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                await func(a, b, c);
            }
            return t;
        }
    }
}
