namespace Solution.Host.Utils;

public class Result
{
    public bool Success { get; set; }

    public bool Failure => !Success;

    public Error? Error { get; set; }
    public Error[]? InnerErrors { get; set; }

    public static implicit operator Result(Error error)
    {
        return new Result() { Success = false, Error = error };
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }


    public static implicit operator Result<T>(Error error)
    {
        return new Result<T>() { Success = false, Error = error };
    }

    public static implicit operator Result<T>(T data)
    {
        return new Result<T>() { Success = true, Data = data };
    }
}
