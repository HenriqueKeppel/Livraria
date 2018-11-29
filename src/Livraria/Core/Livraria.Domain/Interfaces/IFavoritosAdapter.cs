using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IFavoritosAdapter
    {
        Task<IEnumerable<Favorito>> Get();
        Task<Favorito> Get(string isbn);
        Task<IEnumerable<Favorito>> GetByTitle(string titulo);
        Task<bool> Post(Favorito item);
        Task<bool> Delete(string isbn);
    }
}