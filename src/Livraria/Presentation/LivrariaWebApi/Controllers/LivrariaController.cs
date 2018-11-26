using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;

namespace LivrariaWebApi.Controllers
{
    /*
        Controlador que irá concentrar todas as outras api's.
        Tera a chamada por livro em que irá juntar todos os dados,
        assim como as chamadas individuais de manipulação de cada uma.
     */

    [Route("Livraria/v1/api/[controller]")]
    public class LivrariaController : Controller
    {
        private ILivroService _livroService;

        public LivrariaController(ILivroService livroService)
        {
            _livroService = livroService != null ? livroService : throw new ArgumentNullException();
        }

        // GET api/values
        [HttpGet("{isbn}")]
        public async Task<Livro> GetLivroIsbn(string isbn)
        {
            return await _livroService.Obter(isbn);
        }

        [HttpGet("titulo/{titulo}")]
        public async Task<Livro> GetLivroTitulo(string titulo)
        {
            return await _livroService.ObterPorTitulo(titulo);
        }
    }
}
