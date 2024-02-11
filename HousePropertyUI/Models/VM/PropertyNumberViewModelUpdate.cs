using HousePropertyUI.Model.DTO.PropertyNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HousePropertyUI.Models.VM
{
    public class PropertyNumberViewModelUpdate
    {
        public PropertyNumberViewModelUpdate()
        {
            PropertyNumber = new PropertyNumberDTOUpdate();
        }
        public PropertyNumberDTOUpdate PropertyNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PropertyList { get; set; }
    }
}
