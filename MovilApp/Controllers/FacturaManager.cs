using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MovilApp.Models;
using Newtonsoft.Json;

namespace MovilApp.Controllers
{
    class FacturaManager
    {



        string Urlpost = "http://192.168.189.1:45455/api/Factura";

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

           
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }


        public async Task<Factura> Ingresar(Factura factura)
        {
            HttpClient httpClient = GetClient();

            var response = await httpClient.PostAsync(Urlpost,
                new StringContent(JsonConvert.SerializeObject(factura),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Factura>(await response.Content.ReadAsStringAsync());
        }




    }
}
