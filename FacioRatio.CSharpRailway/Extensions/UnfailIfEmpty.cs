using System;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<Empty> UnFailIf(this Result<Empty> t, Func<Exception, bool> func)
        {
            if (func(t.Error))
                return Result.Ok();
            return t;
        }
    }
}
