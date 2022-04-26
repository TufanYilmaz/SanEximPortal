using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class BaseRepo
    {
        private readonly IConfiguration config;

        public BaseRepo(IConfiguration config)
        {
            this.config = config;
        }

        public SqlConnection GetOpenConnection()
        {
            //string cs = config["ConnectionStrings:EximDb"];
            string cs = config.GetConnectionString("EximDb");
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
    }
}
