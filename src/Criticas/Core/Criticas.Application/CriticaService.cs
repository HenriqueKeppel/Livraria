using System;
using System.Collections.Generic;
using Criticas.Domain.Interfaces;
using Criticas.Domain.Models;
using System.Threading.Tasks;

namespace Criticas.Application
{
    public class CriticaService : ICriticaService
    {
        private ICriticaRepository _criticaRepository;

        public CriticaService(ICriticaRepository criticaRepository)
        {
            _criticaRepository = criticaRepository != null ? criticaRepository : throw new ArgumentNullException();
        }

        public async Task<bool> Adicionar(ItemCritica item)
        {
            return await _criticaRepository.Adicionar(item);
        }

        public async Task<bool> Remover(string isbn, int id)
        {
            return await _criticaRepository.Remover(isbn, id);
        }

        public async Task<IEnumerable<ItemCritica>> Obter(string isbn)
        {
            return await _criticaRepository.Obter(isbn);
        }
    }
}
