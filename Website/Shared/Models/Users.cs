using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LCPFavThingsWebsite.Shared.Models
{
    public partial class Users
    {
        #nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; } = 0;
        public string? Username { get; set; }
        public string? PasswordT { get; set; }
        public string? Email { get; set; }
        public string? Pin { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateBirthday { get; set; } = DateTime.UtcNow;
        public string? Avatar { get; set; }
        public string? Cover { get; set; } = "guest.jpg";
        public string? About { get; set; }
        public DateTime DateAccountCreated { get; set; } = DateTime.UtcNow;
        public UsersRoles RoleT { get; set; } = UsersRoles.user;
        public UserToken TokenInfo { get; set; } = null!;
    }

    public partial class UsersWOToken
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; } = 0;
        public string? Username { get; set; }
        public string? PasswordT { get; set; }
        public string? Email { get; set; }
        public string? Pin { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateBirthday { get; set; } = DateTime.UtcNow;
        public string? Avatar { get; set; }
        public string? Cover { get; set; } = "guest.jpg";
        public string? About { get; set; }
        public DateTime DateAccountCreated { get; set; } = DateTime.UtcNow;
        public UsersRoles RoleT { get; set; } = UsersRoles.user;
    }

    public class UserAuth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserAuthId { get; set; } = 0;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UsersRoles RoleT { get; set; } = UsersRoles.user;
        public string? Avatar { get; set; } = "guest.jpg";
        public int UserId { get; set; } = 1;
        public UserToken TokenInfo { get; set; } = null!;
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
        public int TokenId { get; set; } = 0;
        public int Authenticated { get; set; } = 1;
        public string Created { get; set; } = "";
        public string Expiration { get; set; } = "";
        public string AccessToken { get; set; } = "";
        public string Message { get; set; } = "";
        public int UserId { get; set; } = 1;
        public int UserAuthId { get; set; } = 1;
        public Users Users { get; set; } = null!;
        public UserAuth UsersAuth { get; set; } = null!;
    }
}
