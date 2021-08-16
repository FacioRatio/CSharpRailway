using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
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
