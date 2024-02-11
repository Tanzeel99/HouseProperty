using HousePropertyUI.Model.DTO.PropertyNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HousePropertyUI.Models.VM
{
    public class PropertyNumberViewModelDelete
    {
        public PropertyNumberViewModelDelete()
        {
            PropertyNumber = new PropertyNumberDTO();
        }
        public PropertyNumberDTO PropertyNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PropertyList { get; set; }
    }
}
