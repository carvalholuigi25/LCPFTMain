using LCPFavThings.Helpers;
using LCPFavThingsLib.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace LCPFavThings
{
    public static class MyExtensions
    {
        private static string Culture { get; set; } = "pt-PT";

        public static async Task LoadMyCultureInfo(IJSRuntime Js)
        {
            Culture = !string.IsNullOrEmpty(await Js.InvokeAsync<string>("blazorCulture.get")) ? await Js.InvokeAsync<string>("blazorCulture.get") : "pt-PT";
            CultureInfo.CurrentCulture = new CultureInfo(Culture);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(Culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(Culture);
        }

        public static dynamic GetMyConnStringFromLib()
        {
            //var myfileconn = @"{
			//  'connStrings': {
			//	'SQLServerDB': 'Server=(localdb)\\mssqllocaldb;Database=LCPFavThingsDB;Trusted_Connection=True;MultipleActiveResultSets=true',
			//	'SQLiteDB': 'C:\\Users\\Luis\\Documents\\Visual Studio 2022\\Projects\\LCPFTMain\\Webapi\\LCPFavThingsWApi\\Data\\SQLite\\lcpfavthingsdb.db',
			//	'SQLiteDBAndroid': '//sdcard//Android//data//com.lcp.lcpfavthings//files//lcpfavthingsdb.db',
			//	'SQLiteDBAndroidEmu': '//data//data//com.lcp.lcpfavthings//files//lcpfavthingsdb.db',
			//	'MySQLDB': 'server=localhost;port=3306;database=lcpfavthingsdbmysql;user=root;password=1234'
			//  }
			//}";

            var myfileconn = File.ReadAllText(@"C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp\LCPFavThingsLib\Config\myconnstrings.json");
            if (string.IsNullOrEmpty(myfileconn)) return null;
            var contconn = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(myfileconn);
            if (contconn == null || contconn.Count == 0) return null;
            return contconn;
        }

        public static string GetFileDB(string dbmode = "sqlite")
        {
            string pthfile;
            var contconn = GetMyConnStringFromLib();

            if (dbmode == "sqlite")
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    //var pyshicalpth = "/sdcard/Android/data/com.lcp.lcpfavthings/files";
                    //var virtualpth = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    //var sppath = DeviceInfo.DeviceType == DeviceType.Physical ? pyshicalpth : virtualpth;
                    //pthfile = Path.Combine(sppath, "lcpfavthingsdb.db");

                    pthfile = DeviceInfo.DeviceType == DeviceType.Physical ? contconn.connStrings.SQLiteDBAndroid.ToString() : contconn.connStrings.SQLiteDBAndroidEmu.ToString();
                }
                else
                {
                    pthfile = contconn.connStrings.SQLiteDB.ToString();
                }
            }
            else if (dbmode == "sqlserver")
            {
                pthfile = contconn.connStrings.SQLServerDB;

            }
            else if (dbmode == "mysql")
            {
                pthfile = contconn.connStrings.MySQLDB;
            }
            else
            {
                pthfile = @"";
            }

            return pthfile;
        }

        public static string GetDBModeEnv(string dbmode = "sqlite")
        {
            //var envasp = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var dbmode = string.IsNullOrEmpty(envasp) || envasp == "Development" ? "sqlite" : "sqlserver";
            //return dbmode;

            return !string.IsNullOrEmpty(dbmode) ? dbmode : "sqlite";
        }

        public static async Task<T> GetAuthLogin<T>(ILSHelper LSH) where T : class
        {
            return !string.IsNullOrEmpty(await LSH.GetByCl<string>("authinfo")) ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await LSH.GetByCl<string>("authinfo")) : null;
        }

        public static DateTime ConvertToDT(string val)
        {
            return Convert.ToDateTime(val, CultureInfo.InvariantCulture);
        }

        public static UserAuth GenerateToken(string username, int? id = 1)
        {
            ClaimsIdentity identity = new(
                new GenericIdentity(username!, "Login"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, username!)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(3600);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJzdWIiOiI1NDAxODI1ODYwIiwibmFtZSI6Ik1yR3Vlc3QiLCJpYXQiOjU2NjkyMDUwMTkzNH0"));

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "LCPFTIssuer",
                Audience = "LCPFTAudience",
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha384Signature),
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new UserAuth()
            {
                TokenInfo = new UserToken()
                {
                    TokenId = 1,
                    Authenticated = 1,
                    Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    AccessToken = token,
                    Message = "OK",
                    UserId = id
                }
            };
        }
    }
}
