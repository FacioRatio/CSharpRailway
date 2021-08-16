﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<T>> Last<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.LastOrDefault();
            if (value == null)
                return Result.Fail<T>($"{typeof(T).Name} collection is empty.");

            return Result.Ok(value);
        }

        public static async Task<Result<T>> Last<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.LastOrDefault();
            if (value == null)
                return Result.Fail<T>($"{typeof(T).Name} collection is empty.");

            return Result.Ok(value);
        }
    }
}