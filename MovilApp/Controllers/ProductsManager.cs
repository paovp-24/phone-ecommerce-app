using MovilApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.Controllers
{
    class ProductsManager
    {
        string UrlAllProducts = "localhost/api/producto/allProducts";


        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

 
        public async Task<IEnumerable<Products>> ObtenerUsuarios()
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync(UrlAllProducts);

            return JsonConvert.DeserializeObject<IEnumerable<Products>>(resultado);
        }




    }
}
