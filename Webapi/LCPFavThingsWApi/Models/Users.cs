using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCPFavThingsWApi.SecurityApi.JWT;
using LCPFavThingsWApi.Filters;
using erres = LCPFavThingsWApiLib.ErrorResources.ErrorResources;

namespace LCPFavThingsWApi.Models
{
    public partial class Users
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [Display(Name = "UserId")]
        public int? UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
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
        public DateTime? DateBirthday { get; set; }

        [Display(Name = "Avatar")]
        public string? Avatar { get; set; }

        [Display(Name = "Cover")]
        public string? Cover { get; set; } = "guest.jpg";

        [Display(Name = "About")]
        public string? About { get; set; }

        [Display(Name = "Date of Account Created")]
        public DateTime? DateAccountCreated { get; set; } = DateTime.UtcNow;

        [Display(Name = "Role")]
        public UsersRoles? RoleT { get; set; } = UsersRoles.guest;

        [Display(Name = "Token Info")]
        public UserToken? TokenInfo { get; set; }
    }

    public class UserAuth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [SwaggerIgnore]
        [Display(Name = "UserAuthId")]
        public int? UserAuthId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
        public string? Password { get; set; }

        [Display(Name = "Role")]
        [SwaggerIgnore]
        public UsersRoles? RoleT { get; set; } = UsersRoles.user;

        [Display(Name = "Avatar")]
        [SwaggerIgnore]
        public string? Avatar { get; set; }

        [Display(Name = "UserId")]
        [SwaggerIgnore]
        public int? UserId { get; set; } = 1;

        [Display(Name = "Token Info")]
        [SwaggerIgnore]
        [NotMapped]
        public UserToken? TokenInfo { get; set; }
    }

    public enum UsersRoles
    {
        banned = 0,
        guest = 1,
        user = 2,
        admin = 3
    }
}
