using System;
using System.Collections.Generic;
using Favoritos.Domain.Models;
using System.Threading.Tasks;

namespace Favoritos.Domain.Interfaces
{
    public interface IFavoritoService
    {
        Task<bool> Adicionar(Favorito item);
        Task<bool> Remover(string isbn);
        Task<Favorito> Obter(string isbn);
        Task<Favorito> ObterPorTitulo(string titulo);
        Task<IEnumerable<Favorito>> Obter();
    }
}