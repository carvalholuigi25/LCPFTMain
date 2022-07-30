using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCPFavThingsWebsite.Shared.Models
{
    public partial class TVSeries
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "TVSerieId")]
        public int TVSerieId { get; set; } = 0;

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        public string? DescT { get; set; }

        [Display(Name = "Genre")]
        public string? Genre { get; set; }

        [Display(Name = "Category")]
        public string? Category { get; set; }

        [Display(Name = "Cover")]
        public string? Cover { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Display(Name = "Language")]
        public string? LangT { get; set; }

        [Display(Name = "Total Seasons")]
        public int TotalSeasons { get; set; } = 1;

        [Display(Name = "Duration")]
        public int Duration { get; set; } = 1;

        [Display(Name = "Rating")]
        public decimal Rating { get; set; } = 1;

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
