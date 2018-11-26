using System;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IFavoritosAdapter
    {
        Task<Favorito> Get();
        Task<Favorito> Get(string isbn);
        Task<bool> Post(Favorito item);
        Task<bool> Delete(string isbn);
    }
}