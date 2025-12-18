using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Repositories.Interfaces;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public ProductAddResponse AddProduct(ProductInfo request)
        {
            return _repo.AddProduct(request);
        }

        public IEnumerable<ProductListResponse> GetProducts()
        {
            return _repo.GetProducts();
        }

        public ProductInfoView GetProduct(int id)
        {
            return _repo.GetProductById(id);
        }
    }
}
