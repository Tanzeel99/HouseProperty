using HousePropertyUI.Model.DTO.PropertyNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HousePropertyUI.Models.VM
{
    public class PropertyNumberViewModelCreate
    {
        public PropertyNumberViewModelCreate()
        {
            PropertyNumber = new PropertyNumberDTOCreate();
        }
        public PropertyNumberDTOCreate PropertyNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PropertyList { get; set; }
    }
}
