using System;
using Livro.Domain.Interfaces;
using Livro.Domain.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Livro.Service
{
    public class LivroService : ILivroService
    {
        private IRepositoryGet _RepositoryGet;

        public LivroService(IRepositoryGet repositoryGet)        
        {
            _RepositoryGet = repositoryGet != null ? repositoryGet : throw new NullReferenceException("RepositoryGet");
        }
        public async Task<LivroItem> Get(BookGetRequest request)
        {
            LivroItem retorno = null;

            var retornoRepository = await _RepositoryGet.Get(request);

            if (retornoRepository != null)
            {
                // TODO: criar um mapper depois
                // Tratar mais de um registro
                var livro = retornoRepository.items.FirstOrDefault();

                if (livro != null)
                {
                    retorno = new LivroItem
                    {
                        Isbn = livro.volumeInfo.industryIdentifiers.identifier,
                        Titulo = livro.volumeInfo.title,
                        Editora = livro.volumeInfo.publisher,
                        Descricao = livro.volumeInfo.description,
                        Autores = livro.volumeInfo.authors
                    };
                }
            }
            return retorno;
        }
    }
}
