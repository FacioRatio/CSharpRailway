using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultValueOrFallbackTaskTExtensions
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
