using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace libreriaOnline
{
    public class Conexion
    {
        SqlConnection conexiondb;
        public SqlConnection conexion()
        {
            string conexionString = "Data Source=.;Initial Catalog=PruebaPoli;Integrated Security=True";
            conexiondb = new SqlConnection(conexionString);
            return conexiondb;
        }

        public bool EjecutarInsertar(string Query)
        {
            bool status = false;
            try
            {
                conexion().Open();
                SqlCommand CommandExecute = new SqlCommand(Query, conexiondb);
                CommandExecute.ExecuteNonQuery();
                conexion().Close();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public DataTable EjecutarConsultas(string Query)
        {
            var datatable = new DataTable();
            try
            {
                conexiondb.Open();
                SqlCommand commandCount = new SqlCommand(Query, conexiondb);
                using (SqlDataReader reader = commandCount.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        datatable.Load(reader);

                    }
                    else
                    {
                        Console.WriteLine("No se encontraron resultados en la consulta.");
                    }
                }
                conexiondb.Close();
            }
            catch(Exception ex)
            {
            }
            return datatable;
        }
    }
}