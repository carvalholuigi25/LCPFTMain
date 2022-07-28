using Microsoft.EntityFrameworkCore;

namespace LCPFavThingsWApi.Context
{
    public partial class DBLiteContext : DBContext
    {
        public DBLiteContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Configuration.GetSection("ConnectionStrings")["LCPFavThingsDBLite"]);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}
    }
}
