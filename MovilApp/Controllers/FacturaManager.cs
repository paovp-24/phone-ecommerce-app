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

        string Urlpost = "localhost/api/Factura";
        string UrlGetLastId = "localhost/api/factura/getLastID";
        string UrlActualizarMonto = "localhost/api/factura/actualizarMonto";
        string UrlEstadoPagado = "localhost/api/factura/actualizarEstado";

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

        public async Task<int> obtenerUltimoID()
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync(UrlGetLastId);

            var result = JsonConvert.DeserializeObject<Factura>(resultado);

            return result.FACTURA_ID;
        }

        public async Task<IEnumerable<Factura>> ObtenerFactura( Factura factura)
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync($"localhost/api/factura/obtenerFacturas?usuarioID={factura.USUARIO_ID}");

            return JsonConvert.DeserializeObject<IEnumerable<Factura>>(resultado);
        }

        public async Task<Factura> actualizarMontoTotal(Factura fac)
        {
            HttpClient httpClient = GetClient();

            var response = await httpClient.PutAsync(UrlActualizarMonto,
                new StringContent(JsonConvert.SerializeObject(fac),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Factura>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Factura> actualizarEstadoPagado(Factura fac)
        {
            HttpClient httpClient = GetClient();

            var response = await httpClient.PutAsync(UrlEstadoPagado,
                new StringContent(JsonConvert.SerializeObject(fac),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Factura>(await response.Content.ReadAsStringAsync());
        }



    }
}
