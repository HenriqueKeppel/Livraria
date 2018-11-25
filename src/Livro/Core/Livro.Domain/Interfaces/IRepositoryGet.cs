using System;
using Livro.Domain.Models;
using System.Threading.Tasks;

namespace Livro.Domain.Interfaces
{
    public interface IRepositoryGet
    {
        Task<BookGetResponse> Get(BookGetRequest request);

        Task<BookGetResponse> GetByTitle(BookGetRequest request);
    }
}