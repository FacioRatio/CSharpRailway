using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEachTExtensions
    {
        public static Result<Empty> Each<T>(this IEnumerable<T> list, Action<T> func)
        {
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        public static Result<Empty> Each<T>(this IEnumerable<T> list, Func<T, Result<Empty>> func)
        {
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        public static async Task<Result<Empty>> Each<T>(this IEnumerable<T> list, Func<T, Task> func)
        {
            await Task.WhenAll(list.Select(x => func(x)));
            return Result.Ok();
        }

        public static Task<Result<Empty>> Each<T>(this IEnumerable<T> list, Func<T, Task<Result<Empty>>> func)
        {
            return list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }

        public static Result<Empty> Each<T>(this List<T> list, Action<T> func)
        {
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        public static Result<Empty> Each<T>(this List<T> list, Func<T, Result<Empty>> func)
        {
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        public static async Task<Result<Empty>> Each<T>(this List<T> list, Func<T, Task> func)
        {
            await Task.WhenAll(list.Select(x => func(x)));
            return Result.Ok();
        }

        public static Task<Result<Empty>> Each<T>(this List<T> list, Func<T, Task<Result<Empty>>> func)
        {
            return list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }
    }
}
