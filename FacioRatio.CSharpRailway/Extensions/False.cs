using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFalseTExtensions
    {
        public static Result<T> False<T>(this Result<T> t, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return func(t.Value)
                .Bind(yes => !yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        public static Task<Result<T>> False<T>(this Result<T> t, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.FailTask<T>(t.Error);

            return func(t.Value)
                .Bind(yes => !yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        public static Result<T> False<T>(this Result<T> t, Func<T, bool> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return !func(t.Value) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }

        public static async Task<Result<T>> False<T>(this Result<T> t, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return !(await func(t.Value)) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }
    }
}
