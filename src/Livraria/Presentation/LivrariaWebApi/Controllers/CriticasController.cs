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
    public class CriticasController : Controller
    {
        private ICriticaService _criticaService;

        public CriticasController(ICriticaService criticaService)
        {
            _criticaService = criticaService != null ? criticaService : throw new ArgumentNullException();
        }

        [HttpGet("{isbn}")]
        public async Task<IEnumerable<Critica>> Get(string isbn)
        {
            return await _criticaService.Obter(isbn);
        }

        [HttpPost]
        public async Task Post(Critica item)
        {
            await _criticaService.Adicionar(item);
        }

        [HttpDelete("{isbn}/{id}")]
        public async Task<bool> Delete(string isbn, int id)
        {
            return await _criticaService.Remover(isbn, id);
        }
    }
}