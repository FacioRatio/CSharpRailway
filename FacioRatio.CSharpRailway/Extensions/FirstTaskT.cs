using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<T>> First<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            if (value == null)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(value);
        }

        public static async Task<Result<T>> First<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            if (value == null)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(value);
        }
    }
}
