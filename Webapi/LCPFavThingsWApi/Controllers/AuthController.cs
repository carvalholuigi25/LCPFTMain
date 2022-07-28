//source: https://gist.github.com/renatogroffe/90612f4412249218b99e7bbc08a68065/raw/b87d60799922633070c932729ce132431faf5272/LoginController.cs

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LCPFavThingsWApi.SecurityApi.JWT;
using LCPFavThingsWApi.Context;
using Microsoft.EntityFrameworkCore;
using LCPFavThingsWApi.Models;
using Newtonsoft.Json;

namespace LCPFavThingsWApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly DBContext _context;

    public AuthController(DBContext context)
    {
        _context = context;
    }


    private async Task<int?> GetIdFromUser(string? myu)
    {
        return await _context.User.Where(x => x.Username == myu).Select(x => x.UserId).FirstOrDefaultAsync();
    }

    private async Task<string?> GetAvatarFromUser(string? myu)
    {
        return await _context.User.Where(x => x.Username == myu).Select(x => x.Avatar).FirstOrDefaultAsync();
    }

    private async Task<UsersRoles?> GetRoleFromUser(string? myu)
    {
        return await _context.User.Where(x => x.Username == myu).Select(x => x.RoleT).FirstOrDefaultAsync();
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<ActionResult<User?>> Post(
        [FromBody] User utilizador,
        [FromServices] ILogger<AuthController> logger,
        [FromServices] AccessManager accessManager)
    {
        logger.LogInformation($"Recebida solicitação para o utilizador: {utilizador?.Username}");

        if (utilizador is not null && accessManager.ValidateCredentials(utilizador))
        {
            logger.LogInformation($"Sucesso na autenticação do utilizador: {utilizador.Username}");
            return new User()
            {
                UserAuthId = 1,
                Username = utilizador.Username,
                Password = null,
                UserId = await GetIdFromUser(utilizador.Username),
                Avatar = await GetAvatarFromUser(utilizador.Username),
                RoleT = await GetRoleFromUser(utilizador.Username),
                TokenInfo = accessManager.GenerateToken(utilizador, await GetIdFromUser(utilizador.Username))
            };
        }
        else
        {
            logger.LogError($"Falha na autenticação do utilizador: {utilizador?.Username}");
            return new UnauthorizedResult();
        }
    }
}
