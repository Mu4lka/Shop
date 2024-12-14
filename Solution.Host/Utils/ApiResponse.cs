namespace Solution.Host.Utils;

public class ApiResponse
{
    public bool Success { get; set; }
    public ApiError? Error { get; set; }
    public ApiError[]? InnerErrors { get; set; }

    public static ApiResponse Ok()
    {
        return new ApiResponse()
        {
            Success = true,
        };
    }

    public static ApiResponse<T> Ok<T>(T data)
    {
        return new ApiResponse<T>()
        {
            Success = true,
            Data = data
        };
    }
}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }
}