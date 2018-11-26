using System;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class FavoritoService : IFavoritoService
    {
        private IFavoritosAdapter _favoritoAdapter;

        public FavoritoService(IFavoritosAdapter favoritoAdapter)
        {
            _favoritoAdapter = favoritoAdapter != null ? favoritoAdapter : throw new ArgumentNullException();
        }

        public async Task<Favorito> Obter()
        {
            return await _favoritoAdapter.Obter();
        }
        public async Task<Favorito> Obter(string isbn)
        {
            return await _favoritoAdapter.Obter(isbn);
        }
        public async Task Adicionar(Favorito item)
        {
            await _favoritoAdapter.Adicionar(item);
        }
        public async Task Remover(string isbn)
        {
            await _favoritoAdapter.Remover(isbn);
        }
    }
}