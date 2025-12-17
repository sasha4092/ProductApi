using ProductApi.Models;

namespace ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductInfo request);
        IEnumerable<ProductInfo> GetProducts();
        ProductInfoView GetProduct(int id);
    }
}
