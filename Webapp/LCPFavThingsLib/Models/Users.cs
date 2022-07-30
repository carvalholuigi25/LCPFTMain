using LCPFavThingsLib.Filters;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;
using myres = LCPFavThingsLib.Resources.Resources;

namespace LCPFavThingsLib.Models
{
    public partial class Users
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [Display(ResourceType = typeof(myres), Name = nameof(myres.muserid))]
        public int? UserId { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.musername))]
        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mpassword))]
        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
        public string? PasswordT { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.memail))]
        public string? Email { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mpin))]
        public string? Pin { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mfirstname))]
        public string? FirstName { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mlastname))]
        public string? LastName { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mdatebirthday))]
        public DateTime? DateBirthday { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mavatar))]
        public string? Avatar { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mcover))]
        public string? Cover { get; set; } = "guest.jpg";

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mabout))]
        public string? About { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mdateaccreated))]
        public DateTime? DateAccountCreated { get; set; } = DateTime.UtcNow;

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mrole))]
        public UsersRoles? RoleT { get; set; } = UsersRoles.guest;

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mtokeninfo))]
        public UserToken? TokenInfo { get; set; }
    }

    public class UserAuth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [SwaggerIgnore]
        [Display(ResourceType = typeof(myres), Name = nameof(myres.muserauthid))]
        public int? UserAuthId { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.musername))]
        [Required(ErrorMessageResourceName = "EMUsername", ErrorMessageResourceType = typeof(erres))]
        public string? Username { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mpassword))]
        [Required(ErrorMessageResourceName = "EMPassword", ErrorMessageResourceType = typeof(erres))]
        public string? Password { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mrole))]
        [SwaggerIgnore]
        public UsersRoles? RoleT { get; set; } = UsersRoles.user;

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mavatar))]
        [SwaggerIgnore]
        public string? Avatar { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.muserid))]
        [SwaggerIgnore]
        public int? UserId { get; set; } = 1;

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mtokeninfo))]
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
        [Display(ResourceType = typeof(myres), Name = nameof(myres.mtokenid))]
        public int? TokenId { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mauthenticated))]
        public int? Authenticated { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mcreated))]
        public string? Created { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mexpiration))]
        public string? Expiration { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.maccesstoken))]
        public string? AccessToken { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mmessage))]
        public string? Message { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.muserid))]
        public int? UserId { get; set; } = 1;
        
        [Display(ResourceType = typeof(myres), Name = nameof(myres.muserauthid))]
        public int? UserAuthId { get; set; } = 1;
    }
}
