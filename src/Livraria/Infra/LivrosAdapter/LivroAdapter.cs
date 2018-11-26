using System;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace LivrosAdapter
{
    public class LivroAdapter : ILivroAdapter
    {
        private string url = "http://localhost:5000/Livro/v1/api/Livro";
        public async Task<Livro> Obter(string isbn)
        {
            Livro retorno = null;
            var uri = new Uri(string.Format("{0}/{1}", url, isbn));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<Livro>(responseString);
                }
            }
            return retorno;
        }

        public async Task<Livro> ObterPorTitulo(string titulo)
        {
            Livro retorno = null;
            var uri = new Uri(string.Format("{0}/titulo/{1}", url, titulo));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<Livro>(responseString);
                }
            }
            return retorno;
        }
    }
}
