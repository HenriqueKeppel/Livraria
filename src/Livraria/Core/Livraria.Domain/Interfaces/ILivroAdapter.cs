using System;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroAdapter
    {
        Task<Livro> Obter(string isbn);
        Task<Livro> ObterPorTitulo(string titulo);
    }
}