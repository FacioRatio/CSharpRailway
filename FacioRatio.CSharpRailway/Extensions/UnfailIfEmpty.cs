using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultUnfailIfEmptyExtensions
    {
        public static Result<Empty> UnFailIf(this Result<Empty> t, Func<Exception, bool> func)
        {
            if (t.IsSuccess)
                return t;

            if (func(t.Error))
                return Result.Ok();
            return t;
        }

        public static async Task<Result<Empty>> UnFailIf(this Result<Empty> t, Func<Exception, Task<bool>> func)
        {
            if (t.IsSuccess)
                return t;

            if (await func(t.Error))
                return Result.Ok();
            return t;
        }
    }
}
