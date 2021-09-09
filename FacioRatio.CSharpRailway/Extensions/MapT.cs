using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<List<U>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Result<U>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Task<Result<U>>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(func, ignoreFails));
        }

        public static Result<List<U>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, U> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(x => Result.Ok(func(x)), ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Task<U>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(async x => Result.Ok(await func(x)), ignoreFails));
        }

        public static Result<List<U>> Map<T, U>(this Result<List<T>> tList, Func<T, Result<U>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Result<List<T>> tList, Func<T, Task<Result<U>>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(func, ignoreFails));
        }

        public static Result<List<U>> Map<T, U>(this Result<List<T>> tList, Func<T, U> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(x => Result.Ok(func(x)), ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Result<List<T>> tList, Func<T, Task<U>> func, bool ignoreFails = false)
        {
            return tList.Bind(list => list.Map(async x => Result.Ok(await func(x)), ignoreFails));
        }

        public static Result<List<U>> Map<T, U>(this IEnumerable<T> list, Func<T, Result<U>> func, bool ignoreFails = false)
        {
            var results = new List<U>();
            var fails = Result.Ok<U>(default);
            foreach (var item in list)
            {
                var result = func(item);
                if (result.IsSuccess)
                {
                    results.Add(result.Value);
                }
                else if (!ignoreFails)
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<U>>(fails.Error)
                : Result.Ok(results);
        }

        public static async Task<Result<List<U>>> Map<T, U>(this IEnumerable<T> list, Func<T, Task<Result<U>>> func, bool ignoreFails = false)
        {
            var results = new List<U>();
            var fails = Result.Ok<U>(default);
            foreach (var item in list)
            {
                var result = await func(item);
                if (result.IsSuccess)
                {
                    results.Add(result.Value);
                }
                else if (!ignoreFails)
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<U>>(fails.Error)
                : Result.Ok(results);
        }
    }
}
