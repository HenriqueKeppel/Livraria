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
    public class FavoritoServiceTests
    {
        private readonly ServiceProvider serviceProvider;

        public FavoritoServiceTests()
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
                Isbn = "123456",
                IdUsuario = "1",
                DataInclusao = DateTime.Now
            };

            listaMock.Add(itemMock);

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
                Isbn = "789456",
                IdUsuario = "1",
                DataInclusao = DateTime.Now
            };

            var retorno = appService.Adicionar(itemMockAdicionar).Result;

            Assert.True(retorno);
        }
    }
}
