/* source: https://code-maze.com/localization-in-blazor-webassembly-applications/ */

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace LCPFavThings.Shared
{
    public partial class CultureSelector
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] public IJSRuntime Js { get; set; }

        private string _culture;

        CultureInfo[] MyCultures = new[]
        {
            new CultureInfo("pt-PT"),
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("es-ES"),
            new CultureInfo("fr-FR"),
            new CultureInfo("it-IT"),
            new CultureInfo("ja-JP")
        };

        public string Culture
        {
            get => _culture;
            set { _culture = value; }
        }

        protected override async Task OnInitializedAsync()
        {
            Culture = !string.IsNullOrEmpty(await Js.InvokeAsync<string>("blazorCulture.get")) ? await Js.InvokeAsync<string>("blazorCulture.get") : "pt-PT";
            LoadMyCultureInfo(Culture);
            StateHasChanged();
        }

        private void LoadMyCultureInfo(string cval = "pt-PT")
        {
            CultureInfo.CurrentCulture = new CultureInfo(cval);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(cval);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(cval);
        }

        public async Task SetJSValCulture(string value)
        {
            await Js.InvokeVoidAsync("blazorCulture.set", new CultureInfo(value).Name);
        }

        private async Task ChangeCulture(ChangeEventArgs e)
        {
            Culture = e.Value.ToString();
            await SetJSValCulture(Culture);
            LoadMyCultureInfo(Culture);
            NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
        }
    }
}
