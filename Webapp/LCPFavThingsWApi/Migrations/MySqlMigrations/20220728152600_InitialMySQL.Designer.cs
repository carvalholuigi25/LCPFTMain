﻿// <auto-generated />
using System;
using LCPFavThingsWApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LCPFavThingsWApi.Migrations.MySqlMigrations
{
    [DbContext(typeof(DBMySQLContext))]
    [Migration("20220728152600_InitialMySQL")]
    partial class InitialMySQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LCPFavThingsWApi.Models.Games", b =>
                {
                    b.Property<int?>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GameId");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DateRelease")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DescT")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LangT")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Rating")
                        .IsRequired()
                        .HasColumnType("decimal(2,1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("GameId");

                    b.ToTable("Games", (string)null);

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Category = "Games",
                            Company = "Rockstar North",
                            Cover = "gtaiv.jpg",
                            DateRelease = "2008-04-28T00:00:00",
                            DescT = "GTA IV",
                            Genre = "Action,Adventure",
                            LangT = "English",
                            Publisher = "Rockstar Games",
                            Rating = 8m,
                            Title = "GTA IV"
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.Movies", b =>
                {
                    b.Property<int?>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MovieId");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DescT")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<int?>("Duration")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LangT")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("Rating")
                        .IsRequired()
                        .HasColumnType("decimal(2,1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies", (string)null);

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Category = "Movies",
                            Company = "Paramount",
                            Cover = "ff8.jpg",
                            DescT = "The Fast and Furious 8",
                            Duration = 150,
                            Genre = "Action",
                            LangT = "English",
                            Rating = 9m,
                            Title = "The Fast and Furious 8"
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.TVSeries", b =>
                {
                    b.Property<int?>("TVSerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TVSerieId");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DescT")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<int?>("Duration")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LangT")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("Rating")
                        .IsRequired()
                        .HasColumnType("decimal(2,1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TotalSeasons")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("TVSerieId");

                    b.ToTable("TVSeries", (string)null);

                    b.HasData(
                        new
                        {
                            TVSerieId = 1,
                            Category = "TV Series",
                            Company = "AMC,FOX",
                            Cover = "ftwd.jpg",
                            DescT = "FTWD",
                            Duration = 45,
                            Genre = "Action,Adventure",
                            LangT = "English",
                            Rating = 9m,
                            Title = "Fear The Walking Dead",
                            TotalSeasons = 8
                        },
                        new
                        {
                            TVSerieId = 2,
                            Category = "TV Series",
                            Company = "CW,RTP1,AXN",
                            Cover = "theflash.jpg",
                            DescT = "The Flash",
                            Duration = 45,
                            Genre = "Action,Adventure",
                            LangT = "English",
                            Rating = 8m,
                            Title = "The Flash",
                            TotalSeasons = 8
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.UserAuth", b =>
                {
                    b.Property<int?>("UserAuthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserAuthId");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<int?>("RoleT")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserAuthId");

                    b.ToTable("UserAuth", (string)null);

                    b.HasData(
                        new
                        {
                            UserAuthId = 1,
                            Avatar = "guest.jpg",
                            Password = "$2a$11$QJG1aPpzkaEastZAvHUfmORZqieN1pGaYszj3jB69ITgFXN0dmQ.6",
                            RoleT = 1,
                            UserId = 1,
                            Username = "guest"
                        },
                        new
                        {
                            UserAuthId = 2,
                            Avatar = "theflash.jpg",
                            Password = "$2a$11$u/ox4fEf5cAXEeCqLGn8GOwqMb1hLCHlDtyVYcDrWLOAuWFrJ/VF2",
                            RoleT = 3,
                            UserId = 2,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.Users", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("About")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cover")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DateAccountCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateBirthday")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PasswordT")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Pin")
                        .HasColumnType("longtext")
                        .HasColumnName("Pin");

                    b.Property<int?>("RoleT")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            About = "Guest is cool guy!",
                            Avatar = "guest.jpg",
                            Cover = "c_guest.jpg",
                            DateAccountCreated = new DateTime(2022, 7, 28, 15, 25, 59, 207, DateTimeKind.Utc).AddTicks(4961),
                            DateBirthday = new DateTime(1995, 5, 2, 23, 0, 0, 0, DateTimeKind.Utc),
                            Email = "guest@localhost.loc",
                            FirstName = "Guest",
                            LastName = "Convidado",
                            PasswordT = "$2a$11$D..FGHRCBcWTcD44L3lZ9eVaAljiaiuCU3BwP0V0bEnpX79ZsfzKS",
                            Pin = "$2a$11$uk9wFG0emI95gcL3bOsequvdvotc7zHlCC0G04TTHkn3MPeZgf8Bm",
                            RoleT = 1,
                            Username = "guest"
                        },
                        new
                        {
                            UserId = 2,
                            About = "Admin is cool guy!",
                            Avatar = "theflash.jpg",
                            Cover = "theflash.jpg",
                            DateAccountCreated = new DateTime(2022, 7, 28, 15, 25, 59, 552, DateTimeKind.Utc).AddTicks(6301),
                            DateBirthday = new DateTime(1995, 6, 3, 23, 0, 0, 0, DateTimeKind.Utc),
                            Email = "admin@localhost.loc",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordT = "$2a$11$cQ/oILnEoVRPk4E.1GhhTOcPSptA1twSNVnnradr/yfFa/K17gACy",
                            Pin = "$2a$11$gyVuHiRCLTekemRdEC6UoegE6W4Gkpo4DTtt19VmJbVpEvwPVo332",
                            RoleT = 3,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.SecurityApi.JWT.UserToken", b =>
                {
                    b.Property<int?>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TokenId");

                    b.Property<string>("AccessToken")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<int?>("Authenticated")
                        .HasColumnType("int")
                        .HasColumnName("Authenticated");

                    b.Property<string>("Created")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Expiration")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Message")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<int?>("UserAuthId")
                        .HasColumnType("int")
                        .HasColumnName("UserAuthId");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("TokenId");

                    b.HasIndex("UserAuthId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserToken", (string)null);

                    b.HasData(
                        new
                        {
                            TokenId = 1,
                            AccessToken = "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ",
                            Authenticated = 1,
                            Created = "2022-07-14T16:21:00",
                            Expiration = "2022-07-14T17:21:00",
                            Message = "OK",
                            UserAuthId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("LCPFavThingsWApi.SecurityApi.JWT.UserToken", b =>
                {
                    b.HasOne("LCPFavThingsWApi.Models.UserAuth", "UsersAuth")
                        .WithOne("TokenInfo")
                        .HasForeignKey("LCPFavThingsWApi.SecurityApi.JWT.UserToken", "UserAuthId");

                    b.HasOne("LCPFavThingsWApi.Models.Users", "Users")
                        .WithOne("TokenInfo")
                        .HasForeignKey("LCPFavThingsWApi.SecurityApi.JWT.UserToken", "UserId");

                    b.Navigation("Users");

                    b.Navigation("UsersAuth");
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.UserAuth", b =>
                {
                    b.Navigation("TokenInfo");
                });

            modelBuilder.Entity("LCPFavThingsWApi.Models.Users", b =>
                {
                    b.Navigation("TokenInfo");
                });
#pragma warning restore 612, 618
        }
    }
}