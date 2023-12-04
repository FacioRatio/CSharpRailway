using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultMapTaskTExtensions
    {
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Result<U>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<Result<U>>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U> func)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<U>> func)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Result<U>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<Result<U>>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U> func)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<U>> func)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }
    }
}
