using ProductApi.Models;

namespace ProductApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductInfo request);
        IEnumerable<ProductInfo> GetProducts();
        ProductInfoView GetProductById(int id);
    }
}
