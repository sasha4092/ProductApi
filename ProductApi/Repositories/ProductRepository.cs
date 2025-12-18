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

        public ProductInfoView AddProduct(ProductInfo request)
        {
            using var conn = _db.GetConnection();
            //try
            //{
                
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "product.product_pkg.p_ins_product";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_product_name", OracleDbType.Varchar2).Value = request.ProductName;
                cmd.Parameters.Add("p_prod_type_no", OracleDbType.Int32).Value = request.ProductTypeNo;
                cmd.Parameters.Add("p_col_no", OracleDbType.Int32).Value = request.ColNo;
                var statusParam = cmd.Parameters.Add("o_status", OracleDbType.Int32);
                statusParam.Direction = ParameterDirection.Output;

                var messageParam = cmd.Parameters.Add("o_message", OracleDbType.Varchar2, 4000);
                messageParam.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                
                int status = Convert.ToInt32(statusParam.Value.ToString());
                string message = messageParam.Value.ToString();
                if (status == 1)
                {
                    return GetProductByname(request.ProductName);
                }
                else
                {
                    throw new Exception(message);
                }

            //}
            //catch(Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    conn.Close();
            //}
            
        }

        public IEnumerable<ProductListResponse> GetProducts()
        {
            var list = new List<ProductListResponse>();

            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_no, product_name FROM product.product_v order by product_no";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ProductListResponse
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
            cmd.CommandText = "SELECT product_no, product_name, product_type, colours " +
            "FROM product.product_info_v " +
            "WHERE product_no = :id ";
        
            cmd.Parameters.Add(new OracleParameter("id", id));

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                throw new Exception("product id not found");

            return new ProductInfoView
            {
                ProductNo = reader.GetInt32(0),
                ProductName = reader.GetString(1),
                ProdTypeName = reader.GetString(2),
                ColName = reader.GetString(3)
            };
        }

        public ProductInfoView GetProductByname(string name)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_no, product_name, product_type, colours " +
            "FROM product.product_info_v " +
            "WHERE product_name = :name ";

            cmd.Parameters.Add(new OracleParameter("name", name.Trim()));

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
