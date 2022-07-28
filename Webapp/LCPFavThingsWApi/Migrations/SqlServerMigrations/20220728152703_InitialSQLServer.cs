using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCPFavThingsWApi.Migrations.SqlServerMigrations
{
    public partial class InitialSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DescT = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    Genre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cover = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Publisher = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LangT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DateRelease = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DescT = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    Genre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cover = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LangT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "TVSeries",
                columns: table => new
                {
                    TVSerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DescT = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    Genre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cover = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LangT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TotalSeasons = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVSeries", x => x.TVSerieId);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    UserAuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    RoleT = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuth", x => x.UserAuthId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PasswordT = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DateBirthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Cover = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    About = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DateAccountCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoleT = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authenticated = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Expiration = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    AccessToken = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Message = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserAuthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_UserToken_UserAuth_UserAuthId",
                        column: x => x.UserAuthId,
                        principalTable: "UserAuth",
                        principalColumn: "UserAuthId");
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Category", "Company", "Cover", "DateRelease", "DescT", "Genre", "LangT", "Publisher", "Rating", "Title" },
                values: new object[] { 1, "Games", "Rockstar North", "gtaiv.jpg", "2008-04-28T00:00:00", "GTA IV", "Action,Adventure", "English", "Rockstar Games", 8m, "GTA IV" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Category", "Company", "Cover", "DescT", "Duration", "Genre", "LangT", "Rating", "Title" },
                values: new object[] { 1, "Movies", "Paramount", "ff8.jpg", "The Fast and Furious 8", 150, "Action", "English", 9m, "The Fast and Furious 8" });

            migrationBuilder.InsertData(
                table: "TVSeries",
                columns: new[] { "TVSerieId", "Category", "Company", "Cover", "DescT", "Duration", "Genre", "LangT", "Rating", "Title", "TotalSeasons" },
                values: new object[,]
                {
                    { 1, "TV Series", "AMC,FOX", "ftwd.jpg", "FTWD", 45, "Action,Adventure", "English", 9m, "Fear The Walking Dead", 8 },
                    { 2, "TV Series", "CW,RTP1,AXN", "theflash.jpg", "The Flash", 45, "Action,Adventure", "English", 8m, "The Flash", 8 }
                });

            migrationBuilder.InsertData(
                table: "UserAuth",
                columns: new[] { "UserAuthId", "Avatar", "Password", "RoleT", "UserId", "Username" },
                values: new object[,]
                {
                    { 1, "guest.jpg", "$2a$11$QTbXWSA3b3DsuHDkFV8Be.wPQTWpZ5P6eOfozEGve6KXpGdPeqjFm", 1, 1, "guest" },
                    { 2, "theflash.jpg", "$2a$11$PXiD5qQbUAlYe7UAZEDFDudQ4HWHW3U7N63narEEKBUGSscCK3V2a", 3, 2, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "About", "Avatar", "Cover", "DateAccountCreated", "DateBirthday", "Email", "FirstName", "LastName", "PasswordT", "Pin", "RoleT", "Username" },
                values: new object[,]
                {
                    { 1, "Guest is cool guy!", "guest.jpg", "c_guest.jpg", new DateTime(2022, 7, 28, 15, 27, 2, 383, DateTimeKind.Utc).AddTicks(5870), new DateTime(1995, 5, 2, 23, 0, 0, 0, DateTimeKind.Utc), "guest@localhost.loc", "Guest", "Convidado", "$2a$11$wqHUz9o5MebuE36U8.oEluvEJATmHO9iC8E1nrEwoiNjllFqR3iti", "$2a$11$jyG/Zze9o./zDbVPrqKQYuvMxo.lZLro6waPLnuRA32KERTGOQbVO", 1, "guest" },
                    { 2, "Admin is cool guy!", "theflash.jpg", "theflash.jpg", new DateTime(2022, 7, 28, 15, 27, 2, 723, DateTimeKind.Utc).AddTicks(1764), new DateTime(1995, 6, 3, 23, 0, 0, 0, DateTimeKind.Utc), "admin@localhost.loc", "Admin", "Admin", "$2a$11$S9iRChZN7yXAbe/WJfm23e8i0XaToxxghsRkqEYr21Mih18TCv7lC", "$2a$11$V2Ivb6ough2OvrdPFrzdduTFmXvc5XgpmAQCjtNXDMqL/uoWSGiXC", 3, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserToken",
                columns: new[] { "TokenId", "AccessToken", "Authenticated", "Created", "Expiration", "Message", "UserAuthId", "UserId" },
                values: new object[] { 1, "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ", 1, "2022-07-14T16:21:00", "2022-07-14T17:21:00", "OK", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserAuthId",
                table: "UserToken",
                column: "UserAuthId",
                unique: true,
                filter: "[UserAuthId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TVSeries");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "UserAuth");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
