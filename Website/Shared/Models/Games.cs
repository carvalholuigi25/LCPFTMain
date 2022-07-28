using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LCPFavThingsWebsite.Shared.Models
{
    public partial class Games
    {
#nullable enable

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GameId { get; set; } = 0;
        public string? Title { get; set; }
        public string? DescT { get; set; }
        public string? Genre { get; set; }
        public string? Category { get; set; }
        public string? Cover { get; set; }
        public string? Company { get; set; }
        public string? Publisher { get; set; }
        public string? LangT { get; set; }
        public string? DateRelease { get; set; }
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
