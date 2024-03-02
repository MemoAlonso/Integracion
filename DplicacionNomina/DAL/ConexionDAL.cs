using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DplicacionNomina.DAL
{
    public class ConexionDAL
    {
        private SqlConnection Connexion;

        
        public SqlConnection EstablecerConexion()
        {
            try
            {
                this.Connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpleadosConnection"].ConnectionString.ToString());
               
                

            }
            catch (Exception e)
            {
                Console.WriteLine("El error es: " + e);
            }

            return Connexion;
        }

        public bool ProbarConexion()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TBL_EMPLOYEES";
                comando.Connection = this.EstablecerConexion();
                Connexion.Open();
                comando.ExecuteNonQuery();
                Connexion.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EjecutarComandosSinRetorno(string strcomando)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = strcomando;
                comando.Connection = this.EstablecerConexion();
                Connexion.Open();
                comando.ExecuteNonQuery();
                Connexion.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

       public DataSet ConsultarInformacion(SqlCommand sqlcomando) 
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            try 
            {
                SqlCommand comando = new SqlCommand();
                comando= sqlcomando;
                comando.Connection = this.EstablecerConexion();
                adaptador.SelectCommand = comando;
                Connexion.Open();
                adaptador.Fill(ds);
                Connexion.Close();
                return ds;

            }
            catch(Exception ex) 
            { 
               Console.WriteLine("Error en la muestra de los datos" + ex);
                return ds;
            }
        
        }
    }
}