using ProductApi.Models;

namespace ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        ProductAddResponse AddProduct(ProductInfo request);
        IEnumerable<ProductListResponse> GetProducts();
        ProductInfoView GetProduct(int id);
    }
}
