namespace Solution.Host.Utils;

public class ApiError(string message, string? code = null)
{
    public string Message { get; set; } = message;
    public string? Code { get; set; } = code;
}