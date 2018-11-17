using System;
using Livro.Domain.Interfaces;
using Livro.Domain.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Livro.RepositoryGet
{
    public class RepositoryGet : IRepositoryGet
    {
        public string url = "https://www.googleapis.com/books/v1/volumes?q=";
        public async Task<BookGetResponse> Get(BookGetRequest request)
        {
            BookGetResponse retorno = null;
            var uri = new Uri(string.Format("{0}isbn:{1}", url, request.isbn));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<BookGetResponse>(responseString);
                }
            }
            return retorno;
        }
    }
}