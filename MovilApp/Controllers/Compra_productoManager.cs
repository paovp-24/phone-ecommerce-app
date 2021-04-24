using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MovilApp.Models;
using Newtonsoft.Json;

namespace MovilApp.Controllers
{
    class Compra_productoManager
    {


        
        string Urlpost = "localhost/api/Compra_producto";

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }


        public async Task<Compra_producto> Ingresar(Compra_producto compra_producto)
        {
            HttpClient httpClient = GetClient();

            var response = await httpClient.PostAsync(Urlpost,
                new StringContent(JsonConvert.SerializeObject(compra_producto),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Compra_producto>(await response.Content.ReadAsStringAsync());
        }




    }
}