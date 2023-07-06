namespace Choi.WebApi.Dtos;

public sealed record class UserResponseDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
