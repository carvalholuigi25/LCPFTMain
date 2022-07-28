using LCPFavThingsWApi.Models;
using LCPFavThingsWApi.SecurityApi.JWT;
using Microsoft.EntityFrameworkCore;
using bc = BCrypt.Net.BCrypt;

namespace LCPFavThingsWApi.Context
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder mb)
        {
            mb.Entity<Movies>().HasData(new Movies
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
            });

            mb.Entity<Games>().HasData(new Games
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
            });

            mb.Entity<TVSeries>().HasData(new TVSeries
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
            });

            mb.Entity<Users>().HasData(new Users
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
            });

            mb.Entity<UserAuth>().HasData(new UserAuth
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
            });

            mb.Entity<UserToken>().HasData(new UserToken
            {
                TokenId = 1,
                Authenticated = 1,
                AccessToken = "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ",
                Created = "2022-07-14T16:21:00",
                Expiration = "2022-07-14T17:21:00",
                Message = "OK",
                UserId = 1
            });
        }
    }
}
