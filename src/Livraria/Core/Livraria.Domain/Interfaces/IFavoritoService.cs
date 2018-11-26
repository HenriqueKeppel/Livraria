using System;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IFavoritoService
    {
        Task<Favorito> Obter();
        Task<Favorito> Obter(string isbn);
        Task Adicionar(Favorito item);
        Task Remover(string isbn);
    }
}