using System;
using System.Collections.Generic;
using Favoritos.Domain.Interfaces;
using Favoritos.Domain.Models;
using System.Threading.Tasks;

namespace Favoritos.Repository
{
    public class FavoritoRepository : IFavoritoRepository
    {
        public async Task<bool> Adicionar(Favorito item)
        {
            return true;
        }

        public async Task<bool> Remover(string isbn)
        {
            return true;
        }
        public async Task<Favorito> Obter(string isbn)
        {
            Favorito retorno = new Favorito();
            return retorno;
        }

        public async Task<IEnumerable<Favorito>> Obter()
        {
            List<Favorito> retorno= new List<Favorito>();
            return retorno;
        }
    }
}
