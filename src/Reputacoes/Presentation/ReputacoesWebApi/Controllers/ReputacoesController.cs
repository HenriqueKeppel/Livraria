using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reputacoes.Domain.Interfaces;
using Reputacoes.Domain.Models;

namespace ReputacoesWebApi.Controllers
{
    [Route("Reputacoeswebapi/v1/[controller]")]
    public class ReputacoesController : Controller
    {
        private IReputacaoService _reputacaoService;
        public ReputacoesController(IReputacaoService reputacaoService)
        {
            _reputacaoService = reputacaoService != null ? reputacaoService : throw new ArgumentNullException();
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<IEnumerable<Reputacao>> Get(string isbn)
        {
            return await _reputacaoService.Obter(isbn);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Reputacao item)
        {
            await _reputacaoService.Adicionar(item);
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}/{id}")]
        public async Task<bool> Delete(string isbn, int id)        
        {
            return await _reputacaoService.Remover(isbn, id);
        }
    }
}
