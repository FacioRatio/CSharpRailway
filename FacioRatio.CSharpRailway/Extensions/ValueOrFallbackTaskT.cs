using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static async Task<T> ValueOrFallback<T>(this Task<Result<T>> tTask, T fallbackValue = default)
        {
            var t = await tTask;
            if (t.IsFailure)
                return fallbackValue;

            return t.Value;
        }
    }
}
