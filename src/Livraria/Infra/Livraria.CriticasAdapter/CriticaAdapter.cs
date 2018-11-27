using System;
using System.Collections.Generic;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Livraria.CriticasAdapter
{
    public class CriticaAdapter : ICriticasAdapter
    {
        private string url = "http://localhost:5002/Criticas/v1/api";

        public async Task<IEnumerable<Critica>> Get(string isbn)
        {
            IEnumerable<Critica> retorno = null;
            var uri = new Uri(string.Format("{0}/Criticas/{1}", url, isbn));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<IEnumerable<Critica>>(responseString);
                }
            }
            return retorno;
        }

        public async Task Post(Critica item)
        {
            var uri = new Uri(string.Format("{0}/Criticas/", url));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                if(!response.IsSuccessStatusCode)
                    throw new Exception("Falha ao realizar inclusao de critica!");
            }
        }

        public async Task<bool> Delete(string isbn, int id)
        {
            var uri = new Uri(string.Format("{0}/Criticas/{1}/{2}", url, isbn, id));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
