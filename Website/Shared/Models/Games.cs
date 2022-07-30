using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCPFavThingsWebsite.Shared.Models
{
    public partial class Games
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "GameId")]
        public int GameId { get; set; } = 0;

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
        
        [Display(Name = "Publisher")]
        public string? Publisher { get; set; }
        
        [Display(Name = "Language")]
        public string? LangT { get; set; }
        
        [Display(Name = "Date Release")]
        public string? DateRelease { get; set; }
        
        [Display(Name = "Rating")]
        public decimal Rating { get; set; } = 1;

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
