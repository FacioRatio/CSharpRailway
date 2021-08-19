using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<Empty>> UnFailIf(this Task<Result<Empty>> tTask, Func<Exception, bool> func)
        {
            var t = await tTask;
            if (func(t.Error))
                return Result.Ok();
            return t;
        }

        public static async Task<Result<Empty>> UnFailIf(this Task<Result<Empty>> tTask, Func<Exception, Task<bool>> func)
        {
            var t = await tTask;
            if (await func(t.Error))
                return Result.Ok();
            return t;
        }
    }
}
