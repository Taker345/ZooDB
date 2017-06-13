﻿using System;
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especies/5
        public void Delete(int id)
        {
        }
    }
}
