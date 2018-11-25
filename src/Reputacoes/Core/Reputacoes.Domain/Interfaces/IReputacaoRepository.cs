using System;
using System.Collections.Generic;
using Reputacoes.Domain.Models;
using System.Threading.Tasks;

namespace Reputacoes.Domain.Interfaces
{
    public interface IReputacaoRepository
    {
        Task<bool> Adicionar(Reputacao item);
        Task<bool> Remover(string isbn, int id);
        Task<IEnumerable<Reputacao>> Obter(string isbn);
    }
}