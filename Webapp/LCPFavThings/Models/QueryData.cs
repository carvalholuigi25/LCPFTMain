using System.ComponentModel.DataAnnotations;
using static LCPFavThingsLib.Enums.MyEnums;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;

namespace LCPFavThings.Models
{
	public class QueryData
	{
		#nullable enable
		
        [Display(Name = "Query Command")]
        [Required(ErrorMessageResourceName = "EMQryCMD", ErrorMessageResourceType = typeof(erres))]
        public string? QryCommand { get; set; }

        [Display(Name = "SGBD Service")]
        public string? SGBDService { get; set; } = SGBDServiceEnum.sqlite.ToString();
    }
}
