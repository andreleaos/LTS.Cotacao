using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LTS.Cotacao.Infrastructure.Data.Context
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string connectionString) => _connectionString = connectionString;
        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}
