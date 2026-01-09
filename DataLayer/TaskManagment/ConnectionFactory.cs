using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLayer.TaskManagment
{
    public class ConnectionFactory
    {
        private static string _connectionString;

        public static void Configure(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public static IDbConnection DbConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
