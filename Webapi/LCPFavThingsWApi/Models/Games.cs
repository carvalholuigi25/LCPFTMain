using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using erres = LCPFavThingsWApiLib.ErrorResources.ErrorResources;
using myres = LCPFavThingsWApiLib.Resources.Resources;

namespace LCPFavThingsWApi.Models
{
    public partial class Games
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [Display(ResourceType = typeof(myres), Name = nameof(myres.mgamesid))]
        public int? GameId { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mtitle))]
        [Required(ErrorMessageResourceName = "EMTitle", ErrorMessageResourceType = typeof(erres))]
        public string? Title { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mdesc))]
        [Required(ErrorMessageResourceName = "EMDesc", ErrorMessageResourceType = typeof(erres))]
        public string? DescT { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mgenre))]
        [Required(ErrorMessageResourceName = "EMGenre", ErrorMessageResourceType = typeof(erres))]
        public string? Genre { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mcategory))]
        [Required(ErrorMessageResourceName = "EMCategory", ErrorMessageResourceType = typeof(erres))]
        public string? Category { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mcover))]
        [Required(ErrorMessageResourceName = "EMCover", ErrorMessageResourceType = typeof(erres))]
        public string? Cover { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mcompany))]
        [Required(ErrorMessageResourceName = "EMCompany", ErrorMessageResourceType = typeof(erres))]
        public string? Company { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mpublisher))]
        [Required(ErrorMessageResourceName = "EMPublisher", ErrorMessageResourceType = typeof(erres))]
        public string? Publisher { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mlanguage))]
        [Required(ErrorMessageResourceName = "EMLanguage", ErrorMessageResourceType = typeof(erres))]
        public string? LangT { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mdaterelease))]
        [Required(ErrorMessageResourceName = "EMDateRelease", ErrorMessageResourceType = typeof(erres))]
        public string? DateRelease { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mrating))]
        [Required(ErrorMessageResourceName = "EMRating", ErrorMessageResourceType = typeof(erres))]
        [Range(0, 10.0, ErrorMessageResourceName = "EMRatingVal", ErrorMessageResourceType = typeof(erres))]
        public decimal? Rating { get; set; }

        public Games()
        {
            Title = string.Empty;
            DescT = string.Empty;
            Genre = string.Empty;
            Category = string.Empty;
            Company = string.Empty;
            Publisher = string.Empty;
            LangT = string.Empty;
        }
    }
}
