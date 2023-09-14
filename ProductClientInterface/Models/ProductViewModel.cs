using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductClientInterface.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
    }
}
