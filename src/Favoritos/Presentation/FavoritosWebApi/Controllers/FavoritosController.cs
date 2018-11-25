using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Favoritos.Domain.Interfaces;
using Favoritos.Domain.Models;

namespace FavoritosWebApi.Controllers
{
    [Route("Favoritos/v1/api/[controller]")]
    public class FavoritosController : Controller
    {
        private IFavoritoService _FavoritoService;
        public FavoritosController(IFavoritoService favoritoService)
        {
            _FavoritoService = favoritoService != null ? favoritoService : throw new ArgumentNullException();
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Favorito>> Get()
        {
            return await _FavoritoService.Obter();
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<Favorito> Get(string isbn)
        {
            return await _FavoritoService.Obter(isbn);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Favorito item)
        {
            await _FavoritoService.Adicionar(item);
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}")]
        public async Task Delete(string isbn)
        {
            await _FavoritoService.Remover(isbn);
        }
    }
}
