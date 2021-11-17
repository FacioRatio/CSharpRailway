using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABExtensions
    {
        public static Result<(A, B)> Tee<A, B>(this Result<(A, B)> t, Action<A, B> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                func(a, b);
            }
            return t;
        }

        public static async Task<Result<(A, B)>> Tee<A, B>(this Result<(A, B)> t, Func<A, B, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                await func(a, b);
            }
            return t;
        }
    }
}
