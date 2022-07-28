using System.ComponentModel.DataAnnotations;
using static LCPFavThingsLib.Enums.MyEnums;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;

namespace LCPFavThingsLib.Models
{
	public class QueryData
	{
		#nullable enable
		
        [Required(ErrorMessageResourceName = "EMQryCMD", ErrorMessageResourceType = typeof(erres))]
        public string? QryCommand { get; set; }
        public string? SGBDService { get; set; } = SGBDServiceEnum.sqlite.ToString();
    }
}
