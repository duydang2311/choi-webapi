using Choi.WebApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Choi.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed partial class UserController : ControllerBase
{
    private readonly IDbContextFactory<AppDbContext> dbContextFactory;

    public UserController(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }
}
