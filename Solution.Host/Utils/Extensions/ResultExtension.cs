namespace Solution.Host.Utils.Extensions;

public static class ResultExtension
{
    public static ApiResponse ToApiResponse(this Result result)
    {
        return new ApiResponse()
        {
            Success = result.Success,
            Error = result.Error is null ? null : new ApiError(result.Error.Message, result.Error.Code),
            InnerErrors = result.InnerErrors is null ? null : result.InnerErrors.Select(e => new ApiError(e.Message, e.Code)).ToArray()
        };
    }

    public static ApiResponse<T> ToApiResponse<T>(this Result<T> result)
    {
        return new ApiResponse<T>()
        {
            Data = result.Data,
            Success = result.Success,
            Error = result.Error is null ? null : new ApiError(result.Error.Message, result.Error.Code),
            InnerErrors = result.InnerErrors is null ? null : result.InnerErrors.Select(e => new ApiError(e.Message, e.Code)).ToArray()
        };
    }
}
