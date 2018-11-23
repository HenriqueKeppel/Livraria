using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Favoritos.Domain.Interfaces;
using Favoritos.Domain.Models;
using Favoritos.Application;
using Moq;
using System.Linq;

namespace Favoritos.Tests
{
    public class FavoritosApplicationTests
    {
        private readonly ServiceProvider serviceProvider;

        public FavoritosApplicationTests()
        {
            IServiceCollection services = new ServiceCollection();
            var favoritoRepository = new Mock<IFavoritoRepository>();

            // Configura o repositorio
            configurarFavoritoRepository(favoritoRepository);

            services.AddTransient(t => favoritoRepository.Object);
            services.AddTransient<IFavoritoService, Service>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void configurarFavoritoRepository(Mock<IFavoritoRepository> favoritoRepository)
        {
            List<Favorito> listaMock = new List<Favorito>();

            Favorito itemMock = new Favorito
            {
                Titulo = "TestSucess",
                Isbn = "123456",
                IdUsuario = "1",
                DataInclusao = DateTime.Now
            };

            listaMock.Add(itemMock);

            favoritoRepository
                .Setup(s => s.ObterPorTitulo("TestSucess"))
                .ReturnsAsync(itemMock);

            favoritoRepository
                .Setup(s => s.Obter())
                .ReturnsAsync(listaMock);

            favoritoRepository
                .Setup(s => s.Remover("123456"))
                .ReturnsAsync(true);

            favoritoRepository
                .Setup(s => s.Adicionar(It.IsAny<Favorito>()))
                .ReturnsAsync(true);
        }

        [Fact]
        public void ObterPorTituloTestSucess()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();
            var listaRetorno = appService.ObterPorTitulo("TestSucess");
            Assert.True(listaRetorno != null);
        }

        [Fact]
        public void ObterPorTituloTestFail()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();
            var listaRetorno = appService.ObterPorTitulo("TestFail");
            Assert.False(listaRetorno == null);
        }

        [Fact]
        public void ObterPorIsbnTestSucess()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();
            var listaRetorno = appService.ObterPorTitulo("123456");
            Assert.True(listaRetorno != null);
        }

        [Fact]
        public void ObterPorIsbnTestFail()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();
            var listaRetorno = appService.ObterPorTitulo("654321");
            Assert.False(listaRetorno == null);
        }
        
        [Fact]
        public void ObterTestSucess()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();
            var listaRetorno = appService.Obter().Result;
            Assert.True(listaRetorno.ToList().Count > 0);
        }

        [Fact]
        public void AdicionarTestSucess()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();

            Favorito itemMockAdicionar = new Favorito
            {
                Titulo = "TestAdicionar",
                Isbn = "789456",
                IdUsuario = "1",
                DataInclusao = DateTime.Now
            };

            var retorno = appService.Adicionar(itemMockAdicionar).Result;

            Assert.True(retorno);
        }
    }
}
