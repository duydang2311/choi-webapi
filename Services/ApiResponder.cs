using Choi.WebApi.Data;

namespace Choi.WebApi.Services;

public sealed class ApiResponder : IApiResponder
{
    private readonly string version;

    public ApiResponder(string version)
    {
        this.version = version;
    }

    public ApiResponse Empty()
    {
        return new ApiResponse { Version = version };
    }

    public ApiResponse<T> Data<T>(T data)
    {
        return new ApiResponse<T> { Version = version, Data = data };
    }

    public ApiResponse Error(string code, string message = "")
    {
        return new ApiResponse { Version = version, Error = new ErrorResponse { Code = code, Message = message } };
    }

}
