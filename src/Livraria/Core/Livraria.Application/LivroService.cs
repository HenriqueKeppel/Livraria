using System;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class LivroService : ILivroService
    {
        private ILivroAdapter _livroAdapter;

        public LivroService(ILivroAdapter livroAdapter)
        {
            _livroAdapter = livroAdapter != null ? livroAdapter : throw new ArgumentNullException();
        }

        public async Task<Livro> Obter(string isbn)
        {
            return await _livroAdapter.Obter(isbn);
        }

        public async Task<Livro> ObterPorTitulo(string titulo)
        {
            return await _livroAdapter.ObterPorTitulo(titulo);
        }
    }
}
