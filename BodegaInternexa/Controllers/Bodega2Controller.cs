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
    public class Bodega2Controller : ApiController
    {

        INTERNEXAEntities db = new INTERNEXAEntities();
        

        public HttpResponseMessage Get(string idservicio = null,
                                            string cliente = null,
                                            string nombreservicio = null,
                                            string os = null)
        {
            HttpResponseMessage response = null;



            List<obtenerBodegaSolps_Result> result;
            string json = string.Empty;
            try
            {

                result = db.obtenerBodegaSolps(idservicio, cliente, nombreservicio, os).ToList();
                json = JsonConvert.SerializeObject(result);
                
                response = this.Request.CreateResponse(HttpStatusCode.OK);

           
            }
            catch (Exception ex)
            {
                response = this.Request.CreateResponse(HttpStatusCode.BadRequest + "Ex: " +ex.Message);
            }

            //string json = JsonConvert.SerializeObject(result);

            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;

        }


       

    }
}
