using Microsoft.AspNetCore.ResponseCompression;
using LCPFavThingsWebsite.Server.Hubs;
using LCPFavThingsWebsite.Server.Context;
using Serilog;
using LCPFavThingsWebsite.Server.Middlewares;
using LCPFavThingsWebsite.Server.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);
    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);

    builder.Services.AddDbContext<DBContext>();
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    builder.Services.AddSignalR();
    builder.Services.AddResponseCompression(opts =>
    {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            new[] { "application/octet-stream" });
    });

    var app = builder.Build();

    app.UseResponseCompression();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestSerilLogMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();


    app.MapRazorPages();
    app.MapControllers();
    app.MapHub<BroadcastHub>("/broadcasthub");
    app.MapHub<ChatHub>("/chathub");
    app.MapFallbackToFile("index.html");

    app.Run();
} 
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}