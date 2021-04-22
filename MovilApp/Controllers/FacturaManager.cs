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



        string Urlpost = "http://192.168.0.28:45455/api/Factura";
        string UrlGetLastId = "http://192.168.0.28:45455/api/factura/getLastID";


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


        public async Task<IEnumerable<Factura>> ObtenerFacturaId()
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync(UrlGetLastId);

            return JsonConvert.DeserializeObject<IEnumerable<Factura>>(resultado);
        }




    }
}
