using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Result<U>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<Result<U>>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x)), ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<U>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x)), ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Result<U>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<Result<U>>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(func, ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x)), ignoreFails));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<U>> func, bool ignoreFails = false)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x)), ignoreFails));
        }
    }
}
