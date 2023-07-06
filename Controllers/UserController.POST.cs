using AgileObjects.AgileMapper.Extensions;
using Choi.WebApi.Dtos;
using Choi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Choi.WebApi.Controllers;

public sealed partial class UserController : ControllerBase
{
    public class UserPostRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UserResponseDto>> AddUser(UserPostRequestDto dto)
    {
        await using var ctx = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        var user = dto.Map().ToANew<User>();
        user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
        ctx.Add(user);
        await ctx.SaveChangesAsync().ConfigureAwait(false);

        return CreatedAtAction(nameof(AddUser), new { id = user.Id }, user.Map().ToANew<UserResponseDto>());
    }
}
