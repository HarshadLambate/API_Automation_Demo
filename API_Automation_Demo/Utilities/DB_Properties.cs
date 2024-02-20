using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_Demo.Utilities
{
    interface DB_Properties
    {
        IDbConnection OpenDBConnection(string connectionString);
        IDataReader ExecuteDBQuery(string query, IDbConnection dbConnection);
        void CloseConnection(IDbConnection dbConnection);
    }

    public class SQL_DB : DB_Properties
    {
        public IDbConnection OpenDBConnection(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public IDataReader ExecuteDBQuery(string query, IDbConnection dbConnection)
        {
            using (var command = new SqlCommand(query, (SqlConnection)dbConnection))
            {   //using statement to ensure proper resource disposal.
                command.CommandTimeout = 500;
                return command.ExecuteReader();
            }
        }

        public void CloseConnection(IDbConnection dbConnection)
        {
            dbConnection.Close();
        }
    }

    public class NPG_SQL_DB : DB_Properties
    {
        public IDbConnection OpenDBConnection(string connectionString)
        {
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();
            return npgsqlConnection;
        }

        public IDataReader ExecuteDBQuery(string query, IDbConnection dbConnection)
        {
            using(var command = new NpgsqlCommand(query, (NpgsqlConnection)dbConnection))
            {   //using statement to ensure proper resource disposal.
                command.CommandTimeout = 500;
                return command.ExecuteReader();
            }
        }

        public void CloseConnection(IDbConnection dbConnection)
        {
            dbConnection.Close();
        }
    }
}
