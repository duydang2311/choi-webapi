using Choi.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Choi.WebApi.Controllers;

public sealed partial class LoginController : ControllerBase
{
    public class UserLoginDto
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse>> Login(UserLoginDto dto)
    {
        await using var ctx = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
        var user = await ctx.Users
            .Where(e => e.Name == dto.Name || e.Email == dto.Name)
            .Select(e => new { e.Name, e.Email, e.Password })
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        if (user is null)
        {
            return Ok(apiResponder.Error("NOT_FOUND"));
        }

        var ok = BCrypt.Net.BCrypt.EnhancedVerify(dto.Password, user.Password);
        if (!ok)
        {
            return Ok(apiResponder.Error("WRONG"));
        }

        return Ok(apiResponder.Data("TODO: session token"));
    }
}
