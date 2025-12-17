using Oracle.ManagedDataAccess.Client;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Repositories.Interfaces;
using System.Data;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OracleDbContext _db;

        public ProductRepository(OracleDbContext db)
        {
            _db = db;
        }

        public void AddProduct(ProductInfo request)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "product.product_pkg.p_ins_product";
            cmd.CommandType = CommandType.StoredProcedure;

            var param = new OracleParameter
            {
                ParameterName = "p_product_info",
                OracleDbType = OracleDbType.Object,
                UdtTypeName = "PRODUCT.PRODUCT_OBJ_TAB",
                Value = new object[]
                {
                new object[]
                {
                    request.ProductName,
                    request.ProductTypeNo,
                    request.ColNo
                }
                }
            };

            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<ProductInfo> GetProducts()
        {
            var list = new List<ProductInfo>();

            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_no, product_name FROM product.product_v";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ProductInfo
                {
                    ProductNo = reader.GetInt32(0),
                    ProductName = reader.GetString(1)
                });
            }

            return list;
        }

        public ProductInfoView GetProductById(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_no, product_name, product_type, colours" +
            "FROM product.product_info_v" +
            "WHERE product_no = :id ";
        
            cmd.Parameters.Add(new OracleParameter("id", id));

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return new ProductInfoView
            {
                ProductNo = reader.GetInt32(0),
                ProductName = reader.GetString(1),
                ProdTypeName = reader.GetString(2),
                ColName = reader.GetString(3)
            };
        }
    }
}
