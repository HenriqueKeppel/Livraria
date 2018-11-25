using System;
using System.Collections.Generic;
using Criticas.Domain.Models;
using System.Threading.Tasks;

namespace Criticas.Domain.Interfaces
{
    public interface ICriticaRepository
    {
        Task<bool> Adicionar(ItemCritica item);
        Task<bool> Remover(string isbn, int id);
        Task<IEnumerable<ItemCritica>> Obter(string isbn);
    }
}