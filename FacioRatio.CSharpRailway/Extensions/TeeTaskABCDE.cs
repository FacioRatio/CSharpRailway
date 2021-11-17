using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskABCDEExtensions
    {
        public static async Task<Result<(A, B, C, D, E)>> Tee<A, B, C, D, E>(this Task<Result<(A, B, C, D, E)>> tTask, Action<A, B, C, D, E> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                func(a, b, c, d, e);
            }
            return t;
        }

        public static async Task<Result<(A, B, C, D, E)>> Tee<A, B, C, D, E>(this Task<Result<(A, B, C, D, E)>> tTask, Func<A, B, C, D, E, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                await func(a, b, c, d, e);
            }
            return t;
        }
    }
}
