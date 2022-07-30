using System.ComponentModel.DataAnnotations;
using static LCPFavThingsLib.Enums.MyEnums;
using erres = LCPFavThingsLib.ErrorResources.ErrorResources;
using myres = LCPFavThingsLib.Resources.Resources;

namespace LCPFavThingsLib.Models
{
    public class QueryData
    {
#nullable enable

        [Display(ResourceType = typeof(myres), Name = nameof(myres.mqrycmd))]
        [Required(ErrorMessageResourceName = "EMQryCMD", ErrorMessageResourceType = typeof(erres))]
        public string? QryCommand { get; set; }

        [Display(ResourceType = typeof(myres), Name = nameof(myres.msgbdsrv))]
        public string? SGBDService { get; set; } = SGBDServiceEnum.sqlite.ToString();
    }
}
