using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstOrDefaultTExtensions
    {
        public static Result<T> FirstOrDefault<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            return Result.Ok(value);
        }

        public static Result<T> FirstOrDefault<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Ok<T>(default);

            return Result.Ok(t.Value[0]);
        }
    }
}
