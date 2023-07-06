using AgileObjects.AgileMapper.Extensions;
using Choi.WebApi.Data;
using Choi.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Choi.WebApi.Controllers;

public sealed partial class UserController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetUserById(long id)
    {
        await using var ctx = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
        var user = await ctx.Users
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
        if (user is null)
        {
            return NotFound();
        }
        return Ok(apiResponder.Data(user.Map().ToANew<UserResponseDto>()));
    }
}
