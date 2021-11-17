using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskABExtensions
    {
        public static async Task<Result<(A, B)>> Tee<A, B>(this Task<Result<(A, B)>> tTask, Action<A, B> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                func(a, b);
            }
            return t;
        }

        public static async Task<Result<(A, B)>> Tee<A, B>(this Task<Result<(A, B)>> tTask, Func<A, B, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                await func(a, b);
            }
            return t;
        }
    }
}
