using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<T> OnFailure<T>(this Result<T> t, Action<Exception> action)
        {
            if (t.IsFailure)
            {
                action(t.Error);
            }
            return t;
        }

        public static Result<T> OnFailure<T>(this Result<T> t, Func<Exception, Task> action)
        {
            if (t.IsFailure)
            {
                action(t.Error);
            }
            return t;
        }
    }
}
