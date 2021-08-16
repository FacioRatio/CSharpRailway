using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<T> First<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            if (value == null)
                return Result.Fail<T>($"{typeof(T).Name} collection is empty.");

            return Result.Ok(value);
        }

        public static Result<T> First<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            if (value == null)
                return Result.Fail<T>($"{typeof(T).Name} collection is empty.");

            return Result.Ok(value);
        }
    }
}
