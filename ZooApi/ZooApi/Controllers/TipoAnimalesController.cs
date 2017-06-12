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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TipoAnimales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoAnimales/5
        public void Delete(int id)
        {
        }
    }
}
