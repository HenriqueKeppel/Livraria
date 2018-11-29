using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Favorito>> Obter()
        {
            return await _favoritoAdapter.Get();
        }
        public async Task<Favorito> Obter(string isbn)
        {
            return await _favoritoAdapter.Get(isbn);
        }
        public async Task<IEnumerable<Favorito>> ObterPortitulo(string titulo)
        {
            return await _favoritoAdapter.GetByTitle(titulo);
        }
        public async Task<bool> Adicionar(Favorito item)
        {
            return await _favoritoAdapter.Post(item);
        }
        public async Task Remover(string isbn)
        {
            await _favoritoAdapter.Delete(isbn);
        }
    }
}