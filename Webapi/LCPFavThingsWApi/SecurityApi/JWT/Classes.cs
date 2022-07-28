//source: https://raw.githubusercontent.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos/main/APIs.Security.JWT/Classes.cs

using LCPFavThingsWApi.Filters;
using LCPFavThingsWApi.Models;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPFavThingsWApi.SecurityApi.JWT;

public class User : UserAuth { }

public static class Roles
{
    public const string? ROLE_ACESSO_APIS = "Acesso-APIs";
}

public class TokenConfigurations
{
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    public int Seconds { get; set; } = 60;
    public string? SecretJwtKey { get; set; }
}

public class UserToken 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [PrimaryKey]
    public int? TokenId { get; set; }
    public int? Authenticated { get; set; }
    public string? Created { get; set; }
    public string? Expiration { get; set; }
    public string? AccessToken { get; set; }
    public string? Message { get; set; }
    public int? UserId { get; set; } = 1;
    public int? UserAuthId { get; set; } = 1;

    [SwaggerIgnore]
    public Users? Users { get; set; }

    [SwaggerIgnore]
    public UserAuth? UsersAuth { get; set; }
}
