using System;
using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstTExtensions
    {
        public static Result<T> First<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            try
            {
                var value = t.Value.First();
                return Result.Ok(value);
            }
            catch (InvalidOperationException)
            {
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));
            }
        }

        public static Result<T> First<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(t.Value[0]);
        }
    }
}
