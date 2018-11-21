using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Favoritos.Domain.Interface;
using Favoritos.Application;

namespace Favoritos.Tests
{
    private readonly ServiceProvider serviceProvider;

    public class FavoritosApplicationTests
    {
        public FavoritosApplicationTests()
        {
            IServiceCollection services = new ServiceCollection();
            var favoritoRepository = new Mock<IFavoritoRepository>();

            // Configura o repositorio
            configurarFavoritoRepository(favoritoRepository);

            services.AddTransient<IFavoritoService, Service>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void configurarFavoritoRepository(Mock<IFavoritoRepository> favoritoRepository)
        {
            List<Favorito> listaMock = new List<Favorito>();

            Favorito itemMock = new Favorito
            {
                Titulo = "teste",
                Isbn = "123456",
                IdUsuario = 1,
                DataInclusao = DateTime.Now
            };

            listaMock.Add(itemMock);

            favoritoRepository
                .Setup(s => s.ObterPorTitulo("teste"))
                .ReturnsAsync(listaMock);
        }

        [Fact]
        public void Test1()
        {
            var appService = serviceProvider.GetService<IFavoritoService>();

            var listaRetorno = await appService.ObterPorTitulo("teste");

            Assert.True(listaRetorno.Count > 0);
        }
    }
}
