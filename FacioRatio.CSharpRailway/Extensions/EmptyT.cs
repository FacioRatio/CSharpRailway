namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEmptyTExtensions
    {
        public static Result<Empty> Empty<T>(this Result<T> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            return Result.Ok();
        }
    }
}
