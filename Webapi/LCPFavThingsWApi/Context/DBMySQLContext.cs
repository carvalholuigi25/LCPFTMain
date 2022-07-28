using Microsoft.EntityFrameworkCore;

namespace LCPFavThingsWApi.Context
{
    public partial class DBMySQLContext : DBContext
    {
        public DBMySQLContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration.GetSection("ConnectionStrings")["LCPFavThingsDBMySQL"].ToString(), new MySqlServerVersion(new Version(8, 0, 27)));
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}
    }
}
