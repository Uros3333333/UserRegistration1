using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;



namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "UserInfoDB")
        {
            // return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = UserInfo; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; ";
           


            
        }

        public static List<T> LoadData<T> (string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("UserInfoDB")))
            {
                return connection.Query<T>(sql).ToList();
            } 
        }

        public static int SaveData<T> (string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("UserInfoDB")))
            {
                return connection.Execute(sql, data);
            }
        }
    }
}
