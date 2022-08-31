using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HumanTech.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Stock Name")]
        [Required]
        public string StockName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DisplayName("Unit Price")]
        [Required]
        public int UnitPrice { get; set; }
        public bool? IsActive { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime? CreatedDate { get; set; }
    }
}
