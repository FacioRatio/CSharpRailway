namespace FacioRatio.CSharpRailway
{
    public static partial class ResultExtensions
    {
        public static Result<Empty> Empty<T>(this Result<T> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            return Result.Ok();
        }
    }
}
