//source: https://raw.githubusercontent.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos/main/APIs.Security.JWT/ApiSecurityDbContext.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LCPFavThingsWApi.SecurityApi.JWT;

public class ApiSecurityDBCtx : IdentityDbContext<ApplicationUser>
{
    public ApiSecurityDBCtx(DbContextOptions<ApiSecurityDBCtx> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("LCPFavThingsDB");
        }
    }
}