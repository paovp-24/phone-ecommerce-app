using MovilApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.Controllers
{
    class CuotaManager
    {
        string UrlAllCuotas = "http://192.168.88.32:45457/api/cuota/allCuota";


        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

 
        public async Task<IEnumerable<Cuot>> ObtenerCuota()
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync(UrlAllCuotas);

            return JsonConvert.DeserializeObject<IEnumerable<Cuot>>(resultado);
        }




    }
}
