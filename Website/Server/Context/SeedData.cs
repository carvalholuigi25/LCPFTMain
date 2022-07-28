using LCPFavThingsWebsite.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LCPFavThingsWebsite.Server.Context
{
    public static class SeedData
    {

        public static void Seed(this ModelBuilder mb)
        {
            var allm = AllModel.ReadAllM();
            mb.Entity<Movies>().HasData(allm.Movies);
            mb.Entity<Games>().HasData(allm.Games);
            mb.Entity<TVSeries>().HasData(allm.TVSeries);
            mb.Entity<Users>().HasData(allm.Users);
            mb.Entity<UserAuth>().HasData(allm.UsersAuth);
            mb.Entity<UserToken>().HasData(allm.UsersToken);
        }
    }
}