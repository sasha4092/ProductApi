namespace ProductApi.Models
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public int ProductTypeNo { get; set; }
        public int ColNo { get; set; }

    }

    public class ProductListResponse
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }

    }

    public class ProductAddResponse
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public string ColName { get; set; }

        public string ProdTypeName { get; set; }
    }
}
