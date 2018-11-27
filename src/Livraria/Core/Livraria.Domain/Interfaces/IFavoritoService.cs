using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IFavoritoService
    {
        Task<IEnumerable<Favorito>> Obter();
        Task<Favorito> Obter(string isbn);
        Task<IEnumerable<Favorito>> ObterPortitulo(string titulo);
        Task Adicionar(Favorito item);
        Task Remover(int id, string isbn);
    }
}