using Blazored.LocalStorage;
using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using LCPFavThings.Data.SQL;
using LCPFavThings.Data.SQLite;
using LCPFavThings.Helpers;

namespace LCPFavThings;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>()
		.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
		});

        builder.Services
        .AddBlazorise(options => { options.Immediate = true; })
        .AddBootstrap5Providers()
        .AddFontAwesomeIcons();

        builder.Services.AddMauiBlazorWebView();
		#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
        #endif

        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddBlazoredToast();
        builder.Services.AddScoped<ILSHelper, LSHelper>();
        builder.Services.AddSingleton<ILocalDBDataService, LocalDBDataService>();
        builder.Services.AddHttpClient<IAllDataService, AllDataService>(client =>
		{
            client.BaseAddress = new Uri(HTTPHelper.GetMyBaseAddress());
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", " " + SetBearerJWT());
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HTTPHelper.SetBearerJWT());
        }).ConfigurePrimaryHttpMessageHandler(() => HTTPHelper.GetInsecureHandler(0));


		#if ANDROID && DEBUG
				Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
				Platforms.Android.DangerousTrustProvider.Register();
		#endif

		builder.Services.AddLocalization();

        return builder.Build();
    }
}
