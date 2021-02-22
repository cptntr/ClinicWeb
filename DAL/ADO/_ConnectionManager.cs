using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Clinic.Web.DAL.ADO
{
    public class ConnectionManager
    {
        private readonly string connectionString;
        public ConnectionManager()
        {
            /*connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;*/
            connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Clinic;Integrated Security=True";
        }
        public (SqlConnection _connection, SqlCommand _command, SqlTransaction _transaction) CreateConnection(string _procedure)
        {
            SqlConnection _connection = new SqlConnection(connectionString);

            SqlCommand _command = new SqlCommand(_procedure, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            SqlTransaction _transaction = null;// = _connection.BeginTransaction();
            //_command.Transaction = _transaction;

            return (_connection, _command, _transaction);
        }
        public void ExecuteNonQuery(SqlConnection _connection, SqlCommand _command, SqlTransaction _transaction)
        {
            try
            {
                using (_connection)
                {
                    _command.ExecuteNonQuery();
                }
                    ////_transaction.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                ////_transaction.Rollback();
            }
        }
    }
}
