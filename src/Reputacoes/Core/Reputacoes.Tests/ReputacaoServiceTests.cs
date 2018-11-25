using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Reputacoes.Domain.Interfaces;
using Reputacoes.Domain.Models;
using Reputacoes.Application;
using Moq;
using System.Linq;

namespace Reputacoes.Tests
{
    public class ReputacaoServiceTests
    {
        private readonly ServiceProvider serviceProvider;

        public ReputacaoServiceTests()
        {
            IServiceCollection services = new ServiceCollection();
            var reputacaoRepository = new Mock<IReputacaoRepository>();

            configuraReputacaoRepository(reputacaoRepository);

            services.AddTransient(t => reputacaoRepository.Object);
            services.AddTransient<IReputacaoService, ReputacaoService>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void configuraReputacaoRepository(Mock<IReputacaoRepository> ReputacaoRepository)
        {
            ReputacaoRepository
                .Setup(s => s.Adicionar(It.IsAny<Reputacao>()))
                .ReturnsAsync(true);

            List<Reputacao> listaMock = new List<Reputacao>();

            Reputacao itemMock = new Reputacao
            {
                Id = 1,
                Isbn = "123456",
                Autor = "Autor1",
                Nota = 5
            };

            Reputacao itemMock2 = new Reputacao
            {
                Id = 2,
                Isbn = "654321",
                Autor = "Autor1",
                Nota = 4
            };

            listaMock.Add(itemMock);
            listaMock.Add(itemMock2);

            ReputacaoRepository
                .Setup(s => s.Obter("123456"))
                .ReturnsAsync(listaMock.Where(o => o.Isbn == "123456"));

            ReputacaoRepository
                .Setup(s => s.Remover("123456", 1))
                .ReturnsAsync(true);
        }

        [Fact]
        public void AdicionarTestes()
        {
            var appService = serviceProvider.GetService<IReputacaoService>();

            Reputacao itemMock = new Reputacao
            {
                Id = 3,
                Isbn = "789123",
                Autor = "Autor1",
                Nota = 5
            };

            bool retorno = appService.Adicionar(itemMock).Result;

            Assert.True(retorno);
        }

        [Fact]
        public void ObterTestes()
        {
            var appService = serviceProvider.GetService<IReputacaoService>();
            var retorno = appService.Obter("123456").Result.ToList();

            Assert.True(retorno.Count > 0);
        }

        [Fact]
        public void RemoverTestes()
        {
            var appService = serviceProvider.GetService<IReputacaoService>();
            var retorno = appService.Remover("123456", 1).Result;

            Assert.True(retorno);
        }
    }
}
