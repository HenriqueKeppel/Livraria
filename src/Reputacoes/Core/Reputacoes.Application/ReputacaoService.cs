using System;
using System.Collections.Generic;
using Reputacoes.Domain.Interfaces;
using Reputacoes.Domain.Models;
using System.Threading.Tasks;

namespace Reputacoes.Application
{
    public class ReputacaoService : IReputacaoService
    {
        private IReputacaoRepository _reputacaoRepository;

        public ReputacaoService(IReputacaoRepository reputacaoRepository)
        {
            _reputacaoRepository = reputacaoRepository != null ? reputacaoRepository : throw new ArgumentNullException();
        }

        public async Task<bool> Adicionar(Reputacao item)
        {
            return await _reputacaoRepository.Adicionar(item);
        }

        public async Task<bool> Remover(string isbn, int id)
        {
            return await _reputacaoRepository.Remover(isbn, id);
        }

        public async Task<IEnumerable<Reputacao>> Obter(string isbn)
        {
            return await _reputacaoRepository.Obter(isbn);
        }
    }
}
