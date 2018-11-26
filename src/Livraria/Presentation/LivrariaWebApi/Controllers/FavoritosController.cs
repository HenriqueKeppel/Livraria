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
        A partir de um favorito, os outros itens serão chamados
        para compor os dados do livro.

        O gerenciamento de cada registro será feito em seu proprio
        controlador.
     */

    [Route("Livraria/v1/api/[controller]")]
    public class FavoritosController : Controller
    {
        private ILivroService _livroService;
        private IFavoritoService _favoritoService;

        public FavoritosController(ILivroService livroService, IFavoritoService favoritoService)
        {
            _livroService = livroService != null ? livroService : throw new ArgumentNullException();
            _favoritoService = favoritoService != null ? favoritoService : throw new ArgumentNullException();
        }

        // [HttpGet]
        // public async Task<IEnumerable<<Livro>> Get()
        // {
        //     Livro retorno = null;
        //     List<Favorito> favorito = _favoritoService.Obter().Result;

        //     if (favorito != null)
        //     {
        //         retorno = _livroService.Obter(favorito.Isbn).Result;

        //         // if (retorno != null)
        //         // {
        //         //     TODO: obter outros dados
        //         // }
        //     }
        //     return retorno;
        // }

        [HttpGet("{isbn}")]
        public async Task<Livro> GetFavoritoPorIsbn(string isbn)
        {
            Livro retorno = null;
            Favorito favorito = _favoritoService.Obter(isbn).Result;

            if (favorito != null)
            {
                retorno = _livroService.Obter(favorito.Isbn).Result;

                // if (retorno != null)
                // {
                //     TODO: obter outros dados
                // }
            }
            return retorno;
        }
    }
}