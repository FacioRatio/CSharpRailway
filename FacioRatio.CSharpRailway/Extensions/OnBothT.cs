using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<T> OnBoth<T>(this Result<T> t, Action<Result<T>> action)
        {
            action(t);
            return t;
        }

        public static Result<T> OnBoth<T>(this Result<T> t, Action<Task<Result<T>>> action)
        {
            action(Task.FromResult(t));
            return t;
        }

        public static Result<T> OnBoth<T>(this Result<T> t, Func<Result<T>, Task> action)
        {
            action(t);
            return t;
        }

        public static Result<T> OnBoth<T>(this Result<T> t, Func<Task<Result<T>>, Task> action)
        {
            action(Task.FromResult(t));
            return t;
        }
    }
}
