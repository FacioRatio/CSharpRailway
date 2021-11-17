using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEachTaskTExtensions
    {
        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Action<T> func)
        {
            var list = await listTask;
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Result<Empty>> func)
        {
            var list = await listTask;
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Task> func)
        {
            var list = await listTask;
            await Task.WhenAll(list.Select(x => func(x)));
            return Result.Ok();
        }

        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Task<Result<Empty>>> func)
        {
            var list = await listTask;
            return await list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }

        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Action<T> func)
        {
            var list = await listTask;
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Result<Empty>> func)
        {
            var list = await listTask;
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Task> func)
        {
            var list = await listTask;
            await Task.WhenAll(list.Select(x => func (x)));
            return Result.Ok();
        }

        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Task<Result<Empty>>> func)
        {
            var list = await listTask;
            return await list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }
    }
}
