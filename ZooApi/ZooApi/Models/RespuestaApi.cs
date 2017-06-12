using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApi
{
        public class RespuestaAPI
        {
            public int totalElementos { get; set; }
            public string error { get; set; }
            public List<Especies> data { get; set; }
            public List<TipoAnimal> dataAnimal { get; set; }
            public List<Clasificacion> dataClasi { get; set; }
        }
}