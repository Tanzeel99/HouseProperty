using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseProperty.Model
{
    public class PropertyNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;



        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        public Property Property { get; set; }
    }
}
