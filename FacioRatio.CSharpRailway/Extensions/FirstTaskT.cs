using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstTaskTExtensions
    {
        public static async Task<Result<T>> First<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
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

        public static async Task<Result<T>> First<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(t.Value[0]);
        }
    }
}
