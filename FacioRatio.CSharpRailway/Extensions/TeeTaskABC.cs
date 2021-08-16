using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Task<Result<(A, B, C)>> tTask, Action<A, B, C> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                func(a, b, c);
            }
            return t;
        }

        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                await func(a, b, c);
            }
            return t;
        }
    }
}
