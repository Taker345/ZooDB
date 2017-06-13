using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ZooApi.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Clasificacion> listaClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificacion = Db.GET_CLASIFICACION();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Aqui no hay datos ERROR";
            }
            resultado.totalElementos = listaClasificacion.Count;
            resultado.dataClasi = listaClasificacion;
            return resultado;
        }

        // GET: api/Clasificacion/5
        public RespuestaAPI Get(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Clasificacion> listaClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificacion = Db.GET_CLASIFICACION_ID(id);

                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Error";
            }

            resultado.totalElementos = listaClasificacion.Count;
            resultado.dataClasi = listaClasificacion;
            return resultado;

        }

        // POST: api/Clasificacion
        [HttpPost]
        public IHttpActionResult Post([FromBody] Clasificacion clasificacion)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarClasificacion(clasificacion);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error";
            }

            return Ok(respuesta);
        }
        // PUT: api/Clasificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasificacion/5
        public void Delete(int id)
        {
        }
    }
}
