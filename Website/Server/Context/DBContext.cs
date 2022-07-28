using LCPFavThingsWebsite.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LCPFavThingsWebsite.Server.Context
{
    public partial class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Games> Game { get; set; } = null!;
        public DbSet<Movies> Movie { get; set; } = null!;
        public DbSet<TVSeries> TVSerie { get; set; } = null!;
        public DbSet<Users> User { get; set; } = null!;
        public DbSet<UserAuth> UserAuth { get; set; } = null!;
        public DbSet<UserToken> UserToken { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetSection("ConnectionStrings")["LCPFavThingsDB"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasOne<UserToken>(s => s.TokenInfo).WithOne(x => x.Users).HasForeignKey<UserToken>(x => x.UserId);
            modelBuilder.Entity<UserAuth>().HasOne<UserToken>(s => s.TokenInfo).WithOne(x => x.UsersAuth).HasForeignKey<UserToken>(x => x.UserAuthId);

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("Movies");

                entity.Property(e => e.MovieId).HasColumnName("MovieId");
                entity.Property(e => e.Title).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.DescT).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Genre).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Category).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Cover).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Company).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.LangT).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Duration).HasColumnType("int");
                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.ToTable("Games");

                entity.Property(e => e.GameId).HasColumnName("GameId");
                entity.Property(e => e.Title).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.DescT).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Genre).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Category).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Cover).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Company).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Publisher).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.LangT).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.DateRelease).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<TVSeries>(entity =>
            {
                entity.ToTable("TVSeries");

                entity.Property(e => e.TVSerieId).HasColumnName("TVSerieId");
                entity.Property(e => e.Title).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.DescT).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Genre).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Category).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Cover).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Company).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.LangT).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.TotalSeasons).HasColumnType("int");
                entity.Property(e => e.Duration).HasColumnType("int");
                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Username).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.PasswordT).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Pin).HasColumnName("Pin");
                entity.Property(e => e.FirstName).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.DateBirthday).HasColumnType("datetime");
                entity.Property(e => e.Avatar).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Cover).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.About).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.DateAccountCreated).HasColumnType("datetime");
                entity.Property(e => e.RoleT).HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<UserAuth>(entity =>
            {
                entity.ToTable("UserAuth");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthId");
                entity.Property(e => e.Username).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Avatar).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.RoleT).HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("UserToken");

                entity.Property(e => e.TokenId).HasColumnName("TokenId");
                entity.Property(e => e.Authenticated).HasColumnName("Authenticated");
                entity.Property(e => e.Created).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Expiration).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.AccessToken).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.Message).HasMaxLength(1024).IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthId");
            });

            modelBuilder.Seed();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}