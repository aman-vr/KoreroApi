using Dapper;
using KoreroDAL.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KoreroDAL.Implimentation
{
   public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }


        public List<T> LoadData<T, U>(string sqlString, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            var rows =  connection.Query<T>(sqlString, parameters);
            return rows.ToList();
        }

        public int SaveData<U>(string sqlString, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            return  connection.Execute(sqlString, parameters );
        }

    }
}
