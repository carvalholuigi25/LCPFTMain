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
        [Display(Name = "UserId")]
        public int UserId { get; set; } = 0;

        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        public string? PasswordT { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Pin")]
        public string? Pin { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Date Birthday")]
        public DateTime DateBirthday { get; set; } = DateTime.UtcNow;

        [Display(Name = "Avatar")]
        public string? Avatar { get; set; }

        [Display(Name = "Cover")]
        public string? Cover { get; set; } = "guest.jpg";

        [Display(Name = "About")]
        public string? About { get; set; }

        [Display(Name = "Date of Account Created")]
        public DateTime DateAccountCreated { get; set; } = DateTime.UtcNow;

        [Display(Name = "Role")]
        public UsersRoles RoleT { get; set; } = UsersRoles.user;

        [Display(Name = "Token Info")]
        public UserToken TokenInfo { get; set; } = null!;
    }

    public partial class UsersWOToken
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "UserId")]
        public int UserId { get; set; } = 0;

        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        public string? PasswordT { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Pin")]
        public string? Pin { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Date Birthday")]
        public DateTime DateBirthday { get; set; } = DateTime.UtcNow;

        [Display(Name = "Avatar")]
        public string? Avatar { get; set; }

        [Display(Name = "Cover")]
        public string? Cover { get; set; } = "guest.jpg";

        [Display(Name = "About")]
        public string? About { get; set; }

        [Display(Name = "Date of Account Created")]
        public DateTime DateAccountCreated { get; set; } = DateTime.UtcNow;

        [Display(Name = "Role")]
        public UsersRoles RoleT { get; set; } = UsersRoles.user;
    }

    public class UserAuth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "UserAuthId")]
        public int UserAuthId { get; set; } = 0;
        
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Role")]
        public UsersRoles RoleT { get; set; } = UsersRoles.user;

        [Display(Name = "Avatar")]
        public string? Avatar { get; set; } = "guest.jpg";

        [Display(Name = "UserId")]
        public int UserId { get; set; } = 1;

        [Display(Name = "Token Info")]
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
        [Display(Name = "TokenId")]
        public int TokenId { get; set; } = 0;

        [Display(Name = "Authenticated")]
        public int Authenticated { get; set; } = 1;

        [Display(Name = "Created")]
        public string Created { get; set; } = "";

        [Display(Name = "Expiration")]
        public string Expiration { get; set; } = "";
        
        [Display(Name = "Access Token")]
        public string AccessToken { get; set; } = "";
        
        [Display(Name = "Message")]
        public string Message { get; set; } = "";
        
        [Display(Name = "UserId")]
        public int UserId { get; set; } = 1;

        [Display(Name = "UserAuthId")]
        public int UserAuthId { get; set; } = 1;

        public Users Users { get; set; } = null!;
        
        public UserAuth UsersAuth { get; set; } = null!;
    }
}
