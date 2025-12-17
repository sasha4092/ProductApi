namespace ProductApi.Data
{
    using Oracle.ManagedDataAccess.Client;

    public class OracleDbContext
    {
        private readonly IConfiguration _configuration;

        public OracleDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OracleConnection GetConnection()
        {
            return new OracleConnection(
                _configuration.GetConnectionString("OracleDb")
            );
        }
    }
}
