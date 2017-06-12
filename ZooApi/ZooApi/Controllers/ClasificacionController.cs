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

        // POST: api/Clasificacion
        public void Post([FromBody]string value)
        {
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
