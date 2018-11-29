using System;
using System.Collections.Generic;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Livraria.FavoritosAdapter
{
    public class FavoritoAdapter : IFavoritosAdapter
    {
        private string url = "http://localhost:7000/Favoritos";

        public async Task<IEnumerable<Favorito>> Get()
        {
            List<Favorito> retorno = null;
            var uri = new Uri(string.Format("{0}", url));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<List<Favorito>>(responseString);
                }
            }
            return retorno;
        }

        public async Task<Favorito> Get(string isbn)
        {
            Favorito retorno = null;
            var uri = new Uri(string.Format("{0}/{1}", url, isbn));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<Favorito>(responseString);
                }
            }
            return retorno;
        }

        public async Task<IEnumerable<Favorito>> GetByTitle(string titulo)
        {
            List<Favorito> retorno = null;
            var uri = new Uri(string.Format("{0}/titulo/{1}", url, titulo));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<List<Favorito>>(responseString);
                }
            }
            return retorno;
        }

        public async Task<bool> Post(Favorito item)
        {
            var uri = new Uri(string.Format("{0}", url));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Delete(string isbn)
        {
            var uri = new Uri(string.Format("{0}/{1}", url, isbn));

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
