using System;
using System.Collections.Generic;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class CriticaService : ICriticaService
    {
        private ICriticasAdapter _criticaAdapter;

        public CriticaService(ICriticasAdapter criticaAdapter)
        {
            _criticaAdapter = criticaAdapter != null ? criticaAdapter : throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Critica>> Obter(string isbn)
        {
            return await _criticaAdapter.Get(isbn);
        }
        public async Task Adicionar(Critica item)
        {
            await _criticaAdapter.Post(item);
        }
        public async Task<bool> Remover(string isbn, int id)
        {
            return await _criticaAdapter.Delete(isbn, id);
        }
    }
}