using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HousePropertyUI.Model.DTO.PropertyNumber
{
    public class PropertyNumberDTOUpdate
    {
        [Required]
        public int PropertyNo { get; set; }

        public string SpecialDetails { get; set; }


        [Required]
        public int PropertyID { get; set; }
    }
}
