using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultReduceTExtensions
    {
        public static Result<U> Reduce<T, U>(this Result<IEnumerable<T>> tList, Func<T, U, Result<U>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Result<IEnumerable<T>> tList, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Result<U> Reduce<T, U>(this Result<IEnumerable<T>> tList, Func<T, U, U> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Result<IEnumerable<T>> tList, Func<T, U, Task<U>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Result<U> Reduce<T, U>(this Result<List<T>> tList, Func<T, U, Result<U>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Result<List<T>> tList, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Result<U> Reduce<T, U>(this Result<List<T>> tList, Func<T, U, U> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Result<List<T>> tList, Func<T, U, Task<U>> func, U initial = default)
        {
            return tList.Bind(list => list.Reduce(func, initial));
        }

        public static Result<U> Reduce<T, U>(this IEnumerable<T> list, Func<T, U, Result<U>> func, U initial = default)
        {
            var u = initial;
            foreach (var item in list)
            {
                var result = func(item, u);
                if (result.IsSuccess)
                {
                    u = result.ValueOrFallback();
                }
                else
                {
                    return result;
                }
            }
            return Result.Ok(u);
        }

        public static Result<U> Reduce<T, U>(this IEnumerable<T> list, Func<T, U, U> func, U initial = default)
        {
            var u = initial;
            foreach (var item in list)
            {
                u = func(item, u);
            }
            return Result.Ok(u);
        }

        public static async Task<Result<U>> Reduce<T, U>(this IEnumerable<T> list, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            var u = initial;
            foreach (var item in list)
            {
                var result = await func(item, u);
                if (result.IsSuccess)
                {
                    u = result.ValueOrFallback();
                }
                else
                {
                    return result;
                }
            }
            return Result.Ok(u);
        }

        public static async Task<Result<U>> Reduce<T, U>(this IEnumerable<T> list, Func<T, U, Task<U>> func, U initial = default)
        {
            var u = initial;
            foreach (var item in list)
            {
                u = await func(item, u);
            }
            return Result.Ok(u);
        }
    }
}
