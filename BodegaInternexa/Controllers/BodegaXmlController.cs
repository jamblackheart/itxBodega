using BodegaInternexa.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BodegaInternexa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BodegaXmlController : ApiController
    {
        INTERNEXAEntities db = new INTERNEXAEntities();
        // GET api/<controller>
        public IEnumerable<obtenerBodegaSolps_Result> Get(string idservicio = null,
                                            string cliente = null,
                                            string nombreservicio = null,
                                            string os = null)
        {
            var result = db.obtenerBodegaSolps(idservicio, cliente, nombreservicio, os);
            return result;
        }


       

    }
}
