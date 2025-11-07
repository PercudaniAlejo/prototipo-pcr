namespace PCR.Core.Application.Common.Models;

public class Result
{
    public bool Succeeded { get; set; }
    public string[]? Errors { get; set; }

    public static Result Success()
    {
        return new Result { Succeeded = true };
    }

    public static Result Failure(params string[] errors)
    {
        return new Result
        {
            Succeeded = false,
            Errors = errors
        };
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>
        {
            Succeeded = true,
            Data = data
        };
    }

    public new static Result<T> Failure(params string[] errors)
    {
        return new Result<T>
        {
            Succeeded = false,
            Errors = errors
        };
    }
}
