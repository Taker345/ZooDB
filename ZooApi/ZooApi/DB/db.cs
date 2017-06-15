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
       
        
        
        
        //APARTIR DE AQUI ESTAN ESPECIES
        




        //get_especie completo sin filtro
        public static List<Especies> GET_ESPECIE()
        {
            List<Especies> resultado = new List<Especies>();


            string procedimientoAEjecutar = "dbo.GET_ESPECIE";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {

                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["TipoAnimal"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                resultado.Add(especie);

            }

            return resultado;
        }
       
        //get_especie_id completo pero añadiendo filtros
        public static List<Especies> GET_ESPECIES_ID(long idEspecie)
        {
            List<Especies> resultado = new List<Especies>();


            string procedimientoAEjecutar = "dbo.GET_ESPECIES_ID";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idEspecie;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {

                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["TipoAnimal"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                resultado.Add(especie);

            }

            return resultado;
        }

        //post para especies (CREAR NUEVO)
        public static int AgregarEspecie(Especies especie)
        {
            string procedimiento = "dbo.AgregarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "idClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especie.clasificacion.idClasificacion;

            comando.Parameters.Add(parametroClasificacion);

            SqlParameter parametroTipoAnimal = new SqlParameter();
            parametroTipoAnimal.ParameterName = "idTipoAnimal";
            parametroTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroTipoAnimal.SqlValue = especie.tipoAnimal.idTipoAnimal;

            comando.Parameters.Add(parametroTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;

            comando.Parameters.Add(parametroNombre);

            SqlParameter parametroPatas = new SqlParameter();
            parametroPatas.ParameterName = "nPatas";
            parametroPatas.SqlDbType = SqlDbType.NVarChar;
            parametroPatas.SqlValue = especie.nPatas;

            comando.Parameters.Add(parametroPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.NVarChar;
            parametroEsMascota.SqlValue = especie.esMascota;

            comando.Parameters.Add(parametroEsMascota);


            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        //put para especies (ACTUALIZAR)
        public static int ActualizarEspecie(long id, Especies especie)
        {
            string procedimiento = "dbo.ActualizarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "idClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especie.clasificacion.idClasificacion;

            comando.Parameters.Add(parametroClasificacion);

            SqlParameter parametroTipoAnimal = new SqlParameter();
            parametroTipoAnimal.ParameterName = "idTipoAnimal";
            parametroTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroTipoAnimal.SqlValue = especie.tipoAnimal.idTipoAnimal;

            comando.Parameters.Add(parametroTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;

            comando.Parameters.Add(parametroNombre);

            SqlParameter parametroPatas = new SqlParameter();
            parametroPatas.ParameterName = "nPatas";
            parametroPatas.SqlDbType = SqlDbType.NVarChar;
            parametroPatas.SqlValue = especie.nPatas;

            comando.Parameters.Add(parametroPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.NVarChar;
            parametroEsMascota.SqlValue = especie.esMascota;

            comando.Parameters.Add(parametroEsMascota);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        //delete eliminar especie
        public static int EliminarEspecie(long id)
        {
            string procedimiento = "dbo.EliminarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;

            comando.Parameters.Add(parametroId);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }


        //APARTIR DE AQUI ESTAN TIPO DE ANIMALES




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

        //post para animales
        public static int AgregarTipoAnimal(TipoAnimal tipoAnimal)
        {
            string procedimiento = "dbo.AgregarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = tipoAnimal.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        //put para tipoAnimales (ACTUALIZAR)
        public static int ActualizarTipoAnimal(long id, TipoAnimal tipoAnimal)
        {
            string procedimiento = "dbo.ActualizarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = tipoAnimal.denominacion;

            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }
        //delete eliminar TipoAnimales
        public static int EliminarTipoAnimal(long id)
        {
            string procedimiento = "dbo.EliminarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;

            comando.Parameters.Add(parametroId);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }




        //APARTIR DE AQUI ESTAN CLASIFICACIONES



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
        
        //get_clasificacion_id completo pero añadiendo filtros
        public static List<Clasificacion> GET_CLASIFICACION_ID(int idClasificacion)
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimiento = "dbo.GET_CLASIFICACION_ID";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idClasificacion;
            comando.Parameters.Add(parametroId);

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

        //post para clasificacion
        public static int AgregarClasificacion(Clasificacion clasificacion)
        {
            string procedimiento = "dbo.AgregarClasificacion";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = clasificacion.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        //put para clasificacion (ACTUALIZAR)
        public static int ActualizarClasificacion(int id, Clasificacion clasificacion)
        {
            string procedimiento = "dbo.ActualizarClasificacion";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = clasificacion.denominacion;

            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        //delete eliminar Clasificacion
        public static int EliminarClasificacion(long id)
        {
            string procedimiento = "dbo.EliminarClasificacion";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;

            comando.Parameters.Add(parametroId);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }


        //LA QUE ESTAMOS CREANDO AHORA MISMO!!!! 























    }
}
