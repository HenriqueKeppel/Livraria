using System;
using System.Collections.Generic;
using Favoritos.Domain.Interfaces;
using Favoritos.Domain.Models;
using System.Threading.Tasks;

namespace Favoritos.Application
{
    public class Service : IFavoritoService
    {
        private IFavoritoRepository _favoritoRepository;

        public Service(IFavoritoRepository favoritoRepository)
        {
            _favoritoRepository = favoritoRepository != null ? favoritoRepository : throw new ArgumentNullException();
        }

        public async Task<bool> Adicionar(Favorito item)
        {
            return await _favoritoRepository.Adicionar(item);
        }

        public async Task<bool> Remover(string isbn)
        {
            return await _favoritoRepository.Remover(isbn);
        }

        public async Task<Favorito> Obter(string isbn)
        {
            return await _favoritoRepository.Obter(isbn);
        }

        public async Task<Favorito> ObterPorTitulo(string titulo)
        {
            return await _favoritoRepository.ObterPorTitulo(titulo);
        }

        public async Task<IEnumerable<Favorito>> Obter()
        {
            return await _favoritoRepository.Obter();
        }
    }
}
