using LCPFavThingsLib.Models;
using Newtonsoft.Json;
using Blazored.LocalStorage;

namespace LCPFavThings.Helpers
{
    public static class HTTPHelper
    {
        public static readonly ILSHelper lsh;
        public static readonly ISyncLocalStorageService ils;

        public static string GetMyBaseAddress()
        {
            //var isSSL = !string.IsNullOrEmpty(ils.GetItem<string>("isSSL")) ? ils.GetItem<string>("isSSL") : "true";
            var isSSL = "true";
            var port = isSSL == "true" ? 5001 : 5000;
            var httph = isSSL == "true" ? "https" : "http";
            var localAddress = $@"{httph}://localhost:{port}";
            var virtualAddress = $@"{httph}://10.0.2.2:{port}";
            var srvRealAddress = $@"{httph}://192.168.1.67:{port}";

            return DeviceInfo.Platform == DevicePlatform.Android ? (DeviceInfo.DeviceType == DeviceType.Physical ? srvRealAddress : virtualAddress) : localAddress;
        }

        public static HttpClientHandler GetInsecureHandler(int mode = 0)
        {
            HttpClientHandler handler = new HttpClientHandler();

            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if(mode == 0)
                {
                    return true;
                }
                else
                {
                    if (cert.Issuer.Equals("CN=localhost"))
                        return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                }
            };
            
            return handler;
        }

        public static async Task<string> SetBearerJWT()
        {
            var myainfo = lsh != null && !string.IsNullOrEmpty(await lsh.Get("authinfo")) ? await lsh.Get("authinfo") : "";
            var objainfo = myainfo.Length > 0 ? JsonConvert.DeserializeObject<Users>(myainfo) : null;
            return objainfo != null ? (objainfo.TokenInfo != null ? objainfo.TokenInfo.AccessToken : "") : "";
        }
    }
}
