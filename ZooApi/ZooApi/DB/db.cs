using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZooApi
{
    public class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = @"Server=.\sqlexpress;
                                          Database=Zoodb;
                                          User Id=testuser;
                                          Password=!Curso@2017;";

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }


        //get_animales completo sin filtro
        public static List<TipoAnimal> GET_ANIMALES()
        {
            List<TipoAnimal> resultado = new List<TipoAnimal>();


            string procedimientoAEjecutar = "dbo.GET_ANIMALES";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                TipoAnimal tipoAnimal = new TipoAnimal();
                tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tipoAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(tipoAnimal);

            }

            return resultado;
        }

        //get_Clasificaion completo sin filtro
        public static List<Clasificacion> GET_CLASIFICACION()
        {
            List<Clasificacion> resultado = new List<Clasificacion>();


            string procedimientoAEjecutar = "dbo.GET_CLASIFICACION";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                Clasificacion clasificacion = new Clasificacion();
                clasificacion.idClasificacion = (int)reader["idClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();

                resultado.Add(clasificacion);

            }

            return resultado;
        }

        //get_animales_id completo pero añadiendo filtros
        public static List<TipoAnimal> GET_ANIMALES_ID(long idTipoAnimal)
        {
            List<TipoAnimal> resultado = new List<TipoAnimal>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimiento = "dbo.GET_ANIMALES_ID";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idTipoAnimal;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TipoAnimal tipoAnimal = new TipoAnimal();
                tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tipoAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(tipoAnimal);
            }

            return resultado;
        }
       
        //get_clasificacion_id completo pero añadiendo filtros
        public static List<Clasificacion> GET_CLASIFICACION_ID(int idTipoAnimal)
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimiento = "dbo.GET_CLASIFICACION_ID";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idTipoAnimal;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TipoAnimal tipoAnimal = new TipoAnimal();
                tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tipoAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(tipoAnimal);
            }

            return resultado;
        }

    }
}
