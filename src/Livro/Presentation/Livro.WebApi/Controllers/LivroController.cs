using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livro.Domain.Interfaces;
using Livro.Domain.Models;

namespace Livro.WebApi.Controllers
{
    [Route("Livrowebapi/v1/[controller]")]
    public class LivroController : Controller
    {
        private ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService != null ? livroService : throw new ArgumentNullException("ILivroService");
        }

        // GET api/values
        [HttpGet("{isbn}")]
        public Task<LivroItem> Get(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                throw new ArgumentNullException("Isbn não passado!");

            return _livroService.ObterLivro(isbn);
        }

        // GET api/values
        [HttpGet("titulo/{titulo}")]
        public Task<LivroItem> GetByTitulo(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentNullException("Titulo não passado!");

            return _livroService.ObterLivroPorTitulo(titulo);
        }
    }
}
