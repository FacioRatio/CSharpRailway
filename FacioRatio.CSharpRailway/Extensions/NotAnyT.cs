using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<Empty> NotAny<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>($"{typeof(T).Name} collection is not empty.");

            return Result.Ok();
        }

        public static Result<Empty> NotAny<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>($"{typeof(T).Name} collection is not empty.");

            return Result.Ok();
        }
    }
}
