using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Criticas.Domain.Interfaces;
using Criticas.Domain.Models;
using Criticas.Application;
using Moq;
using System.Linq;

namespace Criticas.Tests
{
    public class CriticaServiceTests
    {
        private readonly ServiceProvider serviceProvider;

        public CriticaServiceTests()
        {
            IServiceCollection services = new ServiceCollection();
            var criticaRepository = new Mock<ICriticaRepository>();

            configuraCriticaRepository(criticaRepository);

            services.AddTransient(t => criticaRepository.Object);
            services.AddTransient<ICriticaService, CriticaService>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void configuraCriticaRepository(Mock<ICriticaRepository> criticaRepository)
        {
            criticaRepository
                .Setup(s => s.Adicionar(It.IsAny<ItemCritica>()))
                .ReturnsAsync(true);

            List<ItemCritica> listaMock = new List<ItemCritica>();

            ItemCritica itemMock = new ItemCritica
            {
                Id = 1,
                Isbn = "123456",
                Autor = "Autor1",
                Descricao = "Descricao teste 1"
            };

            ItemCritica itemMock2 = new ItemCritica
            {
                Id = 2,
                Isbn = "654321",
                Autor = "Autor1",
                Descricao = "Descricao teste 2"
            };

            listaMock.Add(itemMock);
            listaMock.Add(itemMock2);

            criticaRepository
                .Setup(s => s.Obter("123456"))
                .ReturnsAsync(listaMock.Where(o => o.Isbn == "123456"));

            criticaRepository
                .Setup(s => s.Remover("123456", 1))
                .ReturnsAsync(true);
        }

        [Fact]
        public void AdicionarTestes()
        {
            var appService = serviceProvider.GetService<ICriticaService>();

            ItemCritica itemMock = new ItemCritica
            {
                Id = 3,
                Isbn = "789123",
                Autor = "Autor1",
                Descricao = "Descricao teste 1"
            };

            bool retorno = appService.Adicionar(itemMock).Result;

            Assert.True(retorno);
        }

        [Fact]
        public void ObterTestes()
        {
            var appService = serviceProvider.GetService<ICriticaService>();
            var retorno = appService.Obter("123456").Result.ToList();

            Assert.True(retorno.Count > 0);
        }

        [Fact]
        public void RemoverTestes()
        {
            var appService = serviceProvider.GetService<ICriticaService>();
            var retorno = appService.Remover("123456", 1).Result;

            Assert.True(retorno);
        }
    }
}
