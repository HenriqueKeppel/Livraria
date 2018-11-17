using System;
using Livro.Domain.Models;
using System.Threading.Tasks;

namespace Livro.Domain.Interfaces
{
    public interface ILivroService
    {
        Task<LivroItem> Get(BookGetRequest request);
    }
}