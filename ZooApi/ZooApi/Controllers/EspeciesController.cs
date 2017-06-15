using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ZooApi.Controllers
{
    public class EspeciesController : ApiController
    {
        // GET: api/Especies
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especies> listaEspecie = new List<Especies>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecie = Db.GET_ESPECIE();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch(Exception ex)
            {
                resultado.error = "Aqui no hay datos ERROR";
            }
            resultado.totalElementos = listaEspecie.Count;
            resultado.data = listaEspecie;
            return resultado;
        }

        // GET: api/Especies/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especies> listaEspecies = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecies = Db.GET_ESPECIES_ID(id);

                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Error";
            }

            resultado.totalElementos = listaEspecies.Count;
            resultado.data = listaEspecies;
            return resultado;

        }

        // POST: api/Especies
        [HttpPost]
        public IHttpActionResult Post([FromBody] Especies especie)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarEspecie(especie);
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

        // PUT: api/Especies/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Especies especie)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarEspecie(id, especie);
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

        // DELETE: api/Especies/5
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
                    filasAfectadas = Db.EliminarEspecie(id);
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
