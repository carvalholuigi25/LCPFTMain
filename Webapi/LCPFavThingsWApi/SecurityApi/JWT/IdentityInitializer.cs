//source: https://raw.githubusercontent.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos/main/APIs.Security.JWT/IdentityInitializer.cs

using Microsoft.AspNetCore.Identity;
using LCPFavThingsWApi.Context;
using bc = BCrypt.Net.BCrypt;

namespace LCPFavThingsWApi.SecurityApi.JWT;

public class IdentityInitializer
{
    private readonly ApiSecurityDBCtx _context;
    private readonly DBContext _dbccontext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityInitializer(
        ApiSecurityDBCtx context,
        DBContext dbcontext,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _dbccontext = dbcontext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Initialize()
    {
        if (_context.Database.EnsureCreated())
        {
            if (!_roleManager.RoleExistsAsync(Roles.ROLE_ACESSO_APIS).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(Roles.ROLE_ACESSO_APIS)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {Roles.ROLE_ACESSO_APIS}.");
                }
            }

            var userlist = _dbccontext.User.ToList();

            if(userlist.Count > 0)
            {
                for(var ulx = 0; ulx < userlist.Count; ulx++)
                {
                    CreateUser(
                        new ApplicationUser()
                        {
                            UserName = userlist[ulx].Username,
                            Email = userlist[ulx].Email,
                            EmailConfirmed = true
                        }, userlist[ulx].PasswordT, Roles.ROLE_ACESSO_APIS);
                }
            }
        }
    }

    private void CreateUser(
        ApplicationUser user,
        string? password,
        string? initialRole = null)
    {
        if (_userManager.FindByNameAsync(user.UserName).Result == null)
        {
            var resultado = _userManager
                .CreateAsync(user, password).Result;

            if (resultado.Succeeded &&
                !String.IsNullOrWhiteSpace(initialRole))
            {
                _userManager.AddToRoleAsync(user, initialRole).Wait();
            }
        }
    }
}
