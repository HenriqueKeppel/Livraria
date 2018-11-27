using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface ICriticasAdapter
    {
        Task<IEnumerable<Critica>> Get(string isbn);
        Task Post(Critica item);
        Task<bool> Delete(string isbn, int id);
    }
}