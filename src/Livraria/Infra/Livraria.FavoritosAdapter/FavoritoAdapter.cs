using System;
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
        private string url = "http://localhost:5001/Favoritos/v1/api";

        public async Task<Favorito> Obter()
        {
            throw new NotImplementedException();
        }

        public async Task<Favorito> Obter(string isbn)
        {
            Favorito retorno = null;
            var uri = new Uri(string.Format("{0}/Favoritos/{1}", url, isbn));

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

        public async Task<bool> Adicionar(Favorito item)
        {
            var uri = new Uri(string.Format("{0}/Favoritos/", url));

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

        public async Task<bool> Remover(string isbn)
        {
            var uri = new Uri(string.Format("{0}/Favoritos/{1}", url, isbn));

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
