namespace Choi.WebApi.Data;

public class ApiResponse<T>
{
    public string Version { get; set; } = string.Empty;
    public ErrorResponse? Error { get; set; }
    public T? Data { get; set; }
}

public class ApiResponse : ApiResponse<object> { }
