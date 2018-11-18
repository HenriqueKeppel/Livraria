using System;
using System.Collections.Generic;
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
        public async Task<LivroItem> ObterLivro(string isbn)
        {
            LivroItem retorno = null;
            BookGetRequest request = new BookGetRequest();

            request.isbn = isbn;

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
                        Isbn = ((List<IndustryIdentifiers>)livro.volumeInfo.industryIdentifiers)[0].identifier,
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
