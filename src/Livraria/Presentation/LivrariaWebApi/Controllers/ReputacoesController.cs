using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;

namespace LivrariaWebApi.Controllers
{
    [Route("Livrariawebapi/v1/[controller]")]
    public class ReputacoesController : Controller
    {
        private IReputacaoService _reputacaoService;

        public ReputacoesController(IReputacaoService reputacaoService)
        {
            _reputacaoService = reputacaoService != null ? reputacaoService : throw new ArgumentNullException();
        }

        [HttpGet("{isbn}")]
        public async Task<IEnumerable<Reputacao>> Get(string isbn)
        {
            return await _reputacaoService.Obter(isbn);
        }

        [HttpPost]
        public async Task Post(Reputacao item)
        {
            await _reputacaoService.Adicionar(item);
        }

        [HttpDelete("{isbn}/{id}")]
        public async Task<bool> Delete(string isbn, int id)
        {
            return await _reputacaoService.Remover(id, isbn);
        }
    }
}