using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultReduceTaskTExtensions
    {
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Result<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, U> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Task<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Result<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, U> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Task<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }
    }
}
