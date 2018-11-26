using System;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IFavoritosAdapter
    {
        Task<Favorito> Obter();
        Task<Favorito> Obter(string isbn);
        Task<bool> Adicionar(Favorito item);
        Task<bool> Remover(string isbn);
    }
}