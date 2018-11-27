using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface ICriticaService
    {
        Task<IEnumerable<Critica>> Obter(string isbn);
        Task Adicionar(Critica item);
        Task<bool> Remover(string isbn, int id);
    }
}