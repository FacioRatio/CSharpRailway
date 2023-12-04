using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFilterTaskTExtensions
    {
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Result<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<Result<bool>>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, bool> func)
        {
            return tListTask.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Result<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Task<Result<bool>>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, bool> func)
        {
            return tListTask.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Task<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }
    }
}
