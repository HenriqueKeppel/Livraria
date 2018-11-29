using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Criticas.Domain.Interfaces;
using Criticas.Domain.Models;

namespace CriticasWebApi.Controllers
{
    [Route("Criticaswebapi/v1/[controller]")]
    public class CriticasController : Controller
    {
        private ICriticaService _criticaService;
        public CriticasController(ICriticaService criticaService)
        {
            _criticaService = criticaService != null ? criticaService : throw new ArgumentNullException();
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<IEnumerable<ItemCritica>> Get(string isbn)
        {
            return await _criticaService.Obter(isbn);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]ItemCritica item)
        {
            await _criticaService.Adicionar(item);
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}/{id}")]
        public async Task<bool> Delete(string isbn, int id)        
        {
            return await _criticaService.Remover(isbn, id);
        }
    }
}
