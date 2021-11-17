using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEmptyTaskTExtensions
    {
        public static async Task<Result<Empty>> Empty<T>(this Task<Result<T>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            return Result.Ok();
        }
    }
}
