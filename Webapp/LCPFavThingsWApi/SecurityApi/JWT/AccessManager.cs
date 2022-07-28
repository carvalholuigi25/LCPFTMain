//source: https://raw.githubusercontent.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos/main/APIs.Security.JWT/AccessManager.cs

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using LCPFavThingsWApi.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using bc = BCrypt.Net.BCrypt;

namespace LCPFavThingsWApi.SecurityApi.JWT;

public class AccessManager
{
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;
    private SigningConfigurations _signingConfigurations;
    private TokenConfigurations _tokenConfigurations;
    private DBContext _context;

    public AccessManager(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        SigningConfigurations signingConfigurations,
        TokenConfigurations tokenConfigurations,
        DBContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _signingConfigurations = signingConfigurations;
        _tokenConfigurations = tokenConfigurations;
        _context = context;
    }

    public bool ValidateCredentials(User user)
    {
        bool credenciaisValidas = false;
        
        if (user is not null && !String.IsNullOrWhiteSpace(user.Username))
        {
            var userIdentity = _userManager.FindByNameAsync(user.Username).Result;
            
            if (userIdentity is not null)
            {
                var userinfo = _context.User.SingleOrDefault(x => x.Username == user.Username);
                bool verified = bc.Verify(user.Password, userinfo?.PasswordT);
                var resultadoLogin = _signInManager.CheckPasswordSignInAsync(userIdentity, userinfo?.PasswordT, false).Result;
                
                if (resultadoLogin.Succeeded || verified)
                {
                    credenciaisValidas = _userManager.IsInRoleAsync(userIdentity, Roles.ROLE_ACESSO_APIS).Result;
                }
            }
        }

        return credenciaisValidas;
    }

    public UserToken GenerateToken(User user, int? id = 1)
    {
        ClaimsIdentity identity = new(
            new GenericIdentity(user.Username!, "Login"),
            new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username!)
            }
        );

        DateTime dataCriacao = DateTime.Now;
        DateTime dataExpiracao = dataCriacao +
            TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _tokenConfigurations.Issuer,
            Audience = _tokenConfigurations.Audience,
            SigningCredentials = _signingConfigurations.SigningCredentials,
            Subject = identity,
            NotBefore = dataCriacao,
            Expires = dataExpiracao
        });
        var token = handler.WriteToken(securityToken);

        return new()
        {
            TokenId = 1,
            Authenticated = 1,
            Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
            Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
            AccessToken = token,
            Message = "OK",
            UserId = id
        };
    }
}