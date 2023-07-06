namespace Choi.WebApi.Data;

public sealed record class ErrorResponse
{
    public required string Code { get; set; }
    public required string Message { get; set; }
}
