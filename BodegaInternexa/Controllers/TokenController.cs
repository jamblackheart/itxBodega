using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BodegaInternexa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {

        [HttpGet]
        public async Task<string> GetAsync()
        {
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/c980e410-0b5c-48bc-bd1a-8b91cabc84bc/oauth2/token");
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            formData.Add(new KeyValuePair<string, string>("client_id", "7d9d4669-0053-4859-98bd-3b76db1e78e9"));
            formData.Add(new KeyValuePair<string, string>("client_secret", "dtR7rwbU2yVEIOmZedecXlU52IJw2gxh9PoDaH5baYo="));
            formData.Add(new KeyValuePair<string, string>("resource", "https://isaempresas.onmicrosoft.com/76c615d8-b58c-4bf0-8470-f90d6df94b9a"));
            request.Content = new FormUrlEncodedContent(formData);
            var response = await client.SendAsync(request);
            var strToken = response.Content.ReadAsStringAsync().Result;
            JObject json = JObject.Parse(strToken);
            strToken = json["access_token"].ToString();
            return strToken;
        }
    }
}
