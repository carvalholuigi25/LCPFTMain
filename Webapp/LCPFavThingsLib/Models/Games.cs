using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;

namespace LCPFavThingsLib.Models
{
    public partial class Games
    {
#nullable enable


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [Display(Name = "GameId")]
        public int? GameId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessageResourceName = "EMTitle", ErrorMessageResourceType = typeof(erres))]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessageResourceName = "EMDesc", ErrorMessageResourceType = typeof(erres))]
        public string? DescT { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessageResourceName = "EMGenre", ErrorMessageResourceType = typeof(erres))]
        public string? Genre { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessageResourceName = "EMCategory", ErrorMessageResourceType = typeof(erres))]
        public string? Category { get; set; }

        [Display(Name = "Cover")]
        [Required(ErrorMessageResourceName = "EMCover", ErrorMessageResourceType = typeof(erres))]
        public string? Cover { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessageResourceName = "EMCompany", ErrorMessageResourceType = typeof(erres))]
        public string? Company { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessageResourceName = "EMPublisher", ErrorMessageResourceType = typeof(erres))]
        public string? Publisher { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessageResourceName = "EMLanguage", ErrorMessageResourceType = typeof(erres))]
        public string? LangT { get; set; }

        [Display(Name = "Date Release")]
        [Required(ErrorMessageResourceName = "EMDateRelease", ErrorMessageResourceType = typeof(erres))]
        public string? DateRelease { get; set; }

        [Display(Name = "Rating")]
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
