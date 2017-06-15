using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApi.Controllers
{
    public class TipoAnimalesController : ApiController
    {
        // GET: api/TipoAnimales
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<TipoAnimal> listaTipoAnimal = new List<TipoAnimal>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaTipoAnimal = Db.GET_ANIMALES();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Aqui no hay datos ERROR";
            }
            resultado.totalElementos = listaTipoAnimal.Count;
            resultado.dataAnimal = listaTipoAnimal;
            return resultado;
        }

        // GET: api/TipoAnimales/5
        public RespuestaAPI Get(long id)
        { 
       RespuestaAPI resultado = new RespuestaAPI();
        List<TipoAnimal> listaTipoAnimal = new List<TipoAnimal>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaTipoAnimal = Db.GET_ANIMALES_ID(id);
                    
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Error";
            }

            resultado.totalElementos = listaTipoAnimal.Count;
            resultado.dataAnimal = listaTipoAnimal;
            return resultado;

        }

        // POST: api/TipoAnimales
        [HttpPost]
        public IHttpActionResult Post([FromBody] TipoAnimal tipoAnimal)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoAnimal(tipoAnimal);
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

        // PUT: api/TipoAnimales/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]TipoAnimal tipoAnimal)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTipoAnimal(id, tipoAnimal);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al actualizar la marca";
            }
            return Ok(respuesta);
        }

        // DELETE: api/TipoAnimales/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarTipoAnimal(id);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al eliminar la marca";
            }
            return Ok(respuesta);
        }
    }
}
