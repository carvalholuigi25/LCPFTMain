using bc = BCrypt.Net.BCrypt;
using System.Linq;
using Newtonsoft.Json;

namespace LCPFavThingsWebsite.Shared.Models
{
    public class AllModel
    {
        #nullable disable

        public List<Games> Games { get; set; }
        public List<Movies> Movies { get; set; }
        public List<TVSeries> TVSeries { get; set; }
        public List<Users> Users { get; set; }
        public List<UserAuth> UsersAuth { get; set; }
        public List<UserToken> UsersToken { get; set; }

        public static AllModel ReadAllM()
        {
            var GamesList = new List<Games>()
            {
                new Games
                {
                    GameId = 1,
                    Title = "GTA IV",
                    DescT = "GTA IV",
                    Category = "Games",
                    Company = "Rockstar North",
                    Publisher = "Rockstar Games",
                    Cover = "gtaiv.jpg",
                    Genre = "Action,Adventure",
                    DateRelease = "2008-04-28T00:00:00",
                    LangT = "English",
                    Rating = 8
                }
            };
            
            var MoviesList = new List<Movies>()
            {
                new Movies
                {
                    MovieId = 1,
                    Title = "The Fast and Furious 8",
                    DescT = "The Fast and Furious 8",
                    Duration = 150,
                    Category = "Movies",
                    Company = "Paramount",
                    Cover = "ff8.jpg",
                    Genre = "Action",
                    LangT = "English",
                    Rating = 9
                }
            };

            var TVSeriesList = new List<TVSeries>()
            {
                new TVSeries
                {
                    TVSerieId = 1,
                    Title = "Fear The Walking Dead",
                    DescT = "FTWD",
                    Category = "TV Series",
                    Company = "AMC,FOX",
                    TotalSeasons = 8,
                    Duration = 45,
                    Cover = "ftwd.jpg",
                    Genre = "Action,Adventure",
                    LangT = "English",
                    Rating = 9
                },
                new TVSeries
                {
                    TVSerieId = 2,
                    Title = "The Flash",
                    DescT = "The Flash",
                    Category = "TV Series",
                    Company = "CW,RTP1,AXN",
                    TotalSeasons = 8,
                    Duration = 45,
                    Cover = "theflash.jpg",
                    Genre = "Action,Adventure",
                    LangT = "English",
                    Rating = 8
                }
            };

            var UsersList = new List<Users>()
            {
                new Users
                {
                    UserId = 1,
                    Username = "guest",
                    PasswordT = bc.HashPassword("guest1234"),
                    Email = "guest@localhost.loc",
                    Pin = bc.HashPassword("1234"),
                    FirstName = "Guest",
                    LastName = "Convidado",
                    DateBirthday = new DateTime(1995, 5, 3).ToUniversalTime(),
                    Avatar = "guest.jpg",
                    Cover = "c_guest.jpg",
                    About = "Guest is cool guy!",
                    DateAccountCreated = DateTime.Now.ToUniversalTime(),
                    RoleT = UsersRoles.guest,
                    TokenInfo = null
                },
                new Users
                {
                    UserId = 2,
                    Username = "admin",
                    PasswordT = bc.HashPassword("admin1234"),
                    Email = "admin@localhost.loc",
                    Pin = bc.HashPassword("1234"),
                    FirstName = "Admin",
                    LastName = "Admin",
                    DateBirthday = new DateTime(1995, 6, 4).ToUniversalTime(),
                    Avatar = "theflash.jpg",
                    Cover = "theflash.jpg",
                    About = "Admin is cool guy!",
                    DateAccountCreated = DateTime.Now.ToUniversalTime(),
                    RoleT = UsersRoles.admin,
                    TokenInfo = null
                }
            };

            var UsersAuthList = new List<UserAuth>()
            {
                new UserAuth
                {
                    UserAuthId = 1,
                    Username = "guest",
                    Password = bc.HashPassword("guest1234"),
                    Avatar = "guest.jpg",
                    RoleT = UsersRoles.guest,
                    UserId = 1,
                    TokenInfo = null
                },
                new UserAuth
                {
                    UserAuthId = 2,
                    Username = "admin",
                    Password = bc.HashPassword("admin1234"),
                    Avatar = "theflash.jpg",
                    RoleT = UsersRoles.admin,
                    UserId = 2,
                    TokenInfo = null
                }
            };

            var UsersTokenList = new List<UserToken>()
            {
                new UserToken
                {
                    TokenId = 1,
                    Authenticated = 1,
                    AccessToken = "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ",
                    Created = "2022-07-14T16:21:00",
                    Expiration = "2022-07-14T17:21:00",
                    Message = "OK",
                    UserId = 1
                }
            };

            return new AllModel
            {
                Users = UsersList,
                Movies = MoviesList,
                Games = GamesList,
                TVSeries = TVSeriesList,
                UsersAuth = UsersAuthList,
                UsersToken = UsersTokenList
            };
        }
    }
}
