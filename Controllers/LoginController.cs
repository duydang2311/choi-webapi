using Choi.WebApi.Database;
using Choi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Choi.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed partial class LoginController : ControllerBase
{
    private readonly IDbContextFactory<AppDbContext> dbContextFactory;
    private readonly IApiResponder apiResponder;

    public LoginController(IDbContextFactory<AppDbContext> dbContextFactory, IApiResponder apiResponder)
    {
        this.dbContextFactory = dbContextFactory;
        this.apiResponder = apiResponder;
    }
}
