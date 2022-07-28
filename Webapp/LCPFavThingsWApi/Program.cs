using LCPFavThingsWApi.Context;
using LCPFavThingsWApi.Filters;
using LCPFavThingsWApi.Hubs;
using LCPFavThingsWApi.SecurityApi.JWT;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//var sgbdsrv = builder.Environment.IsProduction() ? "sqlserver" : "sqlite";
var sgbdsrv = builder.Configuration.GetSection("SGBDServiceMode").Value.ToString();

builder.Services.AddDbContext<ApiSecurityDBCtx>();

if (sgbdsrv == "sqlserver")
{
    builder.Services.AddDbContext<DBContext>();
} 
else if(sgbdsrv == "mysql")
{
    builder.Services.AddDbContext<DBContext, DBMySQLContext>();
}
else
{
    builder.Services.AddDbContext<DBContext, DBLiteContext>();
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LCPFavThings API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = $@"
        JWT Authorization Header - utilizado com Bearer Authentication. {Environment.NewLine}
        Digite 'Bearer' [espaço] e então o seu token no campo debaixo. {Environment.NewLine}
        Exemplo (informar sem aspas): 'Bearer abcdef123456'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    //Source: https://github.com/domaindrivendev/Swashbuckle.WebApi/issues/1230#issuecomment-751962760
    c.SchemaFilter<SwaggerSkipPropertyFilter>();
});

//sources:
//https://renatogroffe.medium.com/net-6-asp-net-core-jwt-swagger-implementando-a-utiliza%C3%A7%C3%A3o-de-tokens-5d04cda20fa8
//https://github.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos
var tokenConfigurations = new TokenConfigurations();
new ConfigureFromConfigurationOptions<TokenConfigurations>(
    builder.Configuration.GetSection("TokenConfigurations"))
        .Configure(tokenConfigurations);

// Aciona a extensão que irá configurar o uso de autenticação e autorização via tokens
builder.Services.AddJwtSecurity(tokenConfigurations);
builder.Services.AddScoped<IdentityInitializer>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});

builder.Services.AddCors(p => p.AddPolicy("lcpcorsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//source: https://github.com/renatogroffe/ASPNETCore6-REST_API-JWT-Swagger_ContagemAcessos
using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<IdentityInitializer>().Initialize();

app.UseCors("lcpcorsapp");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapHub<BroadcastHub>("/broadcastHub");
app.MapHub<ChatHub>("/chatHub");
app.MapFallbackToFile("index.html");

var FileProviderPath = app.Environment.ContentRootPath + "/Assets";

if (!Directory.Exists(FileProviderPath))
{
    Directory.CreateDirectory(FileProviderPath);
}

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(FileProviderPath),
    RequestPath = "/Assets",
    EnableDirectoryBrowsing = true
});

await app.RunAsync();