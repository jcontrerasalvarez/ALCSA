using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ALCGLOBAL
{
    public class BaseDatos
    {
        private string Conexion { get; set; }

        public BaseDatos()
        {
            this.Conexion = ConfigurationManager.AppSettings["CONN"];
        }

        public void SQLExecute(string query)
        {
            using (SqlConnection objConexion = new SqlConnection(this.Conexion))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, objConexion))
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
            }
        }

        public DataTable getResultset(string query)
        {
            DataTable objResultado = new DataTable();
            using (SqlConnection objConexion = new SqlConnection(this.Conexion))
            { 
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, objConexion);
                sqlDataAdapter.Fill(objResultado);
            }
            return objResultado;
        }

        public object getRowValue(string sqlSELECT)
        {
            object objResultado = null;
            using (SqlConnection sqlConnection = new SqlConnection(this.Conexion))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlSELECT, sqlConnection))
                {
                    sqlCommand.Connection.Open();
                    objResultado = sqlCommand.ExecuteScalar();
                    sqlCommand.Connection.Close();
                }
            }
            return objResultado;
        }
    }
}
