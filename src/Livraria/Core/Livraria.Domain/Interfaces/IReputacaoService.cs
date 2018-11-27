using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IReputacaoService
    {
        Task<IEnumerable<Reputacao>> Obter(string isbn);
        Task Adicionar(Reputacao item);
        Task<bool> Remover(int id, string isbn);
    }
}