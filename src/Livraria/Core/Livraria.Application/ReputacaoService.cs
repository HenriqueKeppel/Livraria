using System;
using System.Collections.Generic;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class ReputacaoService : IReputacaoService
    {
        private IReputacoesAdapter _reputacaoAdapter;

        public ReputacaoService(IReputacoesAdapter reputacaoAdapter)
        {
            _reputacaoAdapter = reputacaoAdapter != null ? reputacaoAdapter : throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Reputacao>> Obter(string isbn)
        {
            return await _reputacaoAdapter.Get(isbn);
        }
        public async Task Adicionar(Reputacao item)
        {
            await _reputacaoAdapter.Post(item);
        }
        public async Task<bool> Remover(int id, string isbn)
        {
            return await _reputacaoAdapter.Delete(isbn, id);
        }
    }
}