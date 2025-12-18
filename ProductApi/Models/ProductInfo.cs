using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class ProductInfo
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
        public string ProductName { get; set; } 
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Product type must be greater than 0")]
        [DefaultValue(0)]

        public int ProductTypeNo { get; set; } 
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Color must be greater than 0")]
        [DefaultValue(0)]

        public int ColNo { get; set; } 

    }

    public class ProductListResponse
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }

    }

    public class ProductInfoView
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public string ColName { get; set; }

        public string ProdTypeName { get; set; }
    }
}
