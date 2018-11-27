using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface IReputacoesAdapter
    {
        Task<IEnumerable<Reputacao>> Get(string isbn);
        Task Post(Reputacao item);
        Task<bool> Delete(string isbn, int id);
    }
}