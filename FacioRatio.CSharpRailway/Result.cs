using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public class Result<T>
    {
        internal readonly T Value;
        public readonly Exception Error;

        public bool IsSuccess => Error == default;
        public bool IsFailure => !IsSuccess;

        internal Result(T value, Exception error = default)
        {
            Error = error;
            Value = value;
        }

        public T ValueOrFallback(T fallbackValue = default)
        {
            if (this.IsFailure)
                return fallbackValue;

            return Value;
        }
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static class Result
    {
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, default);
        }

        public static Result<Empty> Ok()
        {
            return new Result<Empty>(default);
        }

        public static Task<Result<T>> OkTask<T>(T value)
        {
            return Task.FromResult(Result.Ok(value));
        }

        public static Task<Result<Empty>> OkTask()
        {
            return Task.FromResult(Result.Ok());
        }

        public static Result<T> Fail<T>(Exception error)
        {
            if (error == default)
                throw new ArgumentNullException(nameof(error));
            return new Result<T>(default, error);
        }

        public static Result<Empty> Fail(Exception error)
        {
            return Fail<Empty>(error);
        }

        public static Result<T> Fail<T>(string error)
        {
            if (error == default)
                throw new ArgumentNullException(nameof(error));
            return Fail<T>(new Exception(error));
        }

        public static Result<Empty> Fail(string error)
        {
            return Fail<Empty>(error);
        }

        public static Task<Result<T>> FailTask<T>(Exception error)
        {
            return Task.FromResult(Fail<T>(error));
        }

        public static Task<Result<Empty>> FailTask(Exception error)
        {
            return FailTask<Empty>(error);
        }

        public static Task<Result<T>> FailTask<T>(string error)
        {
            return Task.FromResult(Fail<T>(error));
        }

        public static Task<Result<Empty>> FailTask(string error)
        {
            return FailTask<Empty>(error);
        }
    }
}
