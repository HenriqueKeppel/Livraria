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
        private ICriticaService _criticaService;
        private IReputacaoService _reputacaoService;

        public FavoritosController(ILivroService livroService, 
                                IFavoritoService favoritoService,
                                ICriticaService criticaService,
                                IReputacaoService reputacaoService)
        {
            _livroService = livroService != null ? livroService : throw new ArgumentNullException();
            _favoritoService = favoritoService != null ? favoritoService : throw new ArgumentNullException();
            _criticaService = criticaService != null ? criticaService : throw new ArgumentNullException();
            _reputacaoService = reputacaoService != null ? reputacaoService : throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> Get()
        {
            List<Livro> listaLivro = new List<Livro>();
            IEnumerable<Favorito> listaFavorito = await _favoritoService.Obter();

            foreach (var favorito in listaFavorito)
            {
                IEnumerable<Critica> listaCriticas = null;
                IEnumerable<Reputacao> listaReputacao = null;
                Livro livro = await _livroService.Obter(favorito.Isbn);

                if (livro != null)
                 {
                    // obter todas as criticas deste livro
                    listaCriticas = await _criticaService.Obter(favorito.Isbn);
                    listaReputacao = await _reputacaoService.Obter(favorito.Isbn);

                    livro.Criticas = listaCriticas;
                    livro.Reputacoes = listaReputacao;
                 }
                listaLivro.Add(livro);
            }
            return listaLivro;
        }

        [HttpGet("{isbn}")]
        public async Task<Livro> Get(string isbn)
        {
            Livro livro = null;
            IEnumerable<Critica> listaCriticas = null;
            IEnumerable<Reputacao> listaReputacao = null;
            Favorito favorito = await _favoritoService.Obter(isbn);

            if (favorito != null)
            {
                livro = await _livroService.Obter(favorito.Isbn);

                 if (livro != null)
                 {
                    // obter todas as criticas deste livro
                    listaCriticas = await _criticaService.Obter(favorito.Isbn);
                    listaReputacao = await _reputacaoService.Obter(favorito.Isbn);

                    livro.Criticas = listaCriticas;
                    livro.Reputacoes = listaReputacao;
                 }
            }
            return livro;
        }

        [HttpGet("titulo/{titulo}")]
        public async Task<IEnumerable<Livro>> GetByTitulo(string titulo)
        {
            List<Livro> listaLivro = new List<Livro>();
            IEnumerable<Favorito> listaFavorito = await _favoritoService.ObterPortitulo(titulo);

            foreach (var favorito in listaFavorito)
            {
                IEnumerable<Critica> listaCriticas = null;
                IEnumerable<Reputacao> listaReputacao = null;
                Livro livro = await _livroService.Obter(favorito.Isbn);

                if (livro != null)
                 {
                    // obter todas as criticas deste livro
                    listaCriticas = await _criticaService.Obter(favorito.Isbn);
                    listaReputacao = await _reputacaoService.Obter(favorito.Isbn);

                    livro.Criticas = listaCriticas;
                    livro.Reputacoes = listaReputacao;
                 }
                listaLivro.Add(livro);
            }
            return listaLivro;
        }

        [HttpPost]
        public async Task Post(Favorito favorito)
        {
            await _favoritoService.Adicionar(favorito);
        }

        [HttpDelete("{id}/{isbn}")]
        public async Task Delete(int id, string isbn)
        {
            await _favoritoService.Remover(id, isbn);
        }
    }
}
