using LCPFavThingsLib.Filters;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;

namespace LCPFavThingsLib.Models
{
    public partial class Users
    {
        #nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        public int? UserId { get; set; }

        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
        public string? PasswordT { get; set; }

        public string? Email { get; set; }
        public string? Pin { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateBirthday { get; set; }
        public string? Avatar { get; set; }
        public string? Cover { get; set; } = "guest.jpg";
        public string? About { get; set; }
        public DateTime? DateAccountCreated { get; set; } = DateTime.UtcNow;
        public UsersRoles? RoleT { get; set; } = UsersRoles.user;
        public UserToken? TokenInfo { get; set; }
    }

    public class UserAuth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [SwaggerIgnore]
        public int? UserAuthId { get; set; }

        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
        public string? Password { get; set; }

        [SwaggerIgnore]
        public UsersRoles? RoleT { get; set; } = UsersRoles.user;

        [SwaggerIgnore]
        public string? Avatar { get; set; } = "guest.jpg";

        [SwaggerIgnore]
        public int? UserId { get; set; } = 1;

        [SwaggerIgnore]
        //[NotMapped]
        public UserToken? TokenInfo { get; set; }
    }

    public enum UsersRoles
    {
        banned = 0,
        guest = 1,
        user = 2,
        admin = 3
    }

    public class UserToken
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey]
        public int? TokenId { get; set; }
        public int? Authenticated { get; set; }
        public string? Created { get; set; }
        public string? Expiration { get; set; }
        public string? AccessToken { get; set; }
        public string? Message { get; set; }
        public int? UserId { get; set; } = 1;
        public int? UserAuthId { get; set; } = 1;
    }
}
