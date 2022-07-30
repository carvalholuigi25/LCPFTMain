using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;

namespace LCPFavThings.Models
{
    public partial class TVSeries
    {
        #nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [PrimaryKey, AutoIncrement]
        [Display(Name = "TVSerieId")]
        public int? TVSerieId { get; set; }

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

        [Display(Name = "Comapny")]
        [Required(ErrorMessageResourceName = "EMCompany", ErrorMessageResourceType = typeof(erres))]
        public string? Company { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessageResourceName = "EMLanguage", ErrorMessageResourceType = typeof(erres))]
        public string? LangT { get; set; }

        [Display(Name = "Total Seasons")]
        [Required(ErrorMessageResourceName = "EMTotalSeasons", ErrorMessageResourceType = typeof(erres))]
        [Range(0, 50, ErrorMessageResourceName = "EMTotalSeasonsVal", ErrorMessageResourceType = typeof(erres))]
        public int? TotalSeasons { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessageResourceName = "EMDuration", ErrorMessageResourceType = typeof(erres))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "EMDurationVal", ErrorMessageResourceType = typeof(erres))]
        public int? Duration { get; set; }

        [Display(Name = "Rating")]
        [Required(ErrorMessageResourceName = "EMRating", ErrorMessageResourceType = typeof(erres))]
        [Range(0, 10.0, ErrorMessageResourceName = "EMRatingVal", ErrorMessageResourceType = typeof(erres))]
        public decimal? Rating { get; set; }

        public TVSeries()
        {
            Title = string.Empty;
            DescT = string.Empty;
            Genre = string.Empty;
            Category = string.Empty;
            Company = string.Empty;
            LangT = string.Empty;
        }
    }
}
