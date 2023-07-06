using Choi.WebApi.Data;

namespace Choi.WebApi.Services;

public interface IApiResponder
{
    ApiResponse Empty();
    ApiResponse<T> Data<T>(T data);
    ApiResponse Error(string code, string message = "");
}
