using ProductApi.Models;

namespace ProductApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        ProductAddResponse AddProduct(ProductInfo request);
        IEnumerable<ProductListResponse> GetProducts();
        ProductInfoView GetProductById(int id);
    }
}
