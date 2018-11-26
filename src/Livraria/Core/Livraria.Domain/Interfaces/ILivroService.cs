using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroService
    {
        Task<Livro> Obter(string isbn);
        Task<Livro> ObterPorTitulo(string titulo);
    }
}