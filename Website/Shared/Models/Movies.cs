using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCPFavThingsWebsite.Shared.Models
{
    public partial class Movies
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MovieId { get; set; } = 0;
        public string? Title { get; set; }
        public string? DescT { get; set; }
        public string? Genre { get; set; }
        public string? Category { get; set; }
        public string? Cover { get; set; }
        public string? Company { get; set; }
        public string? LangT { get; set; }
        public int Duration { get; set; } = 1;
        public decimal Rating { get; set; } = 1;

        public Movies()
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
