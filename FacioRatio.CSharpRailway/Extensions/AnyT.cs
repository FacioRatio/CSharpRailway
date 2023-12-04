using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultAnyTExtensions
    {
        public static Result<IEnumerable<T>> Any<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<IEnumerable<T>>(t.Error);

            if (!t.Value.Any())
                return Result.Fail<IEnumerable<T>>(new NotFoundException(typeof(T).Name));

            return t;
        }

        public static Result<List<T>> Any<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<List<T>>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<List<T>>(new NotFoundException(typeof(T).Name));

            return t;
        }
    }
}
