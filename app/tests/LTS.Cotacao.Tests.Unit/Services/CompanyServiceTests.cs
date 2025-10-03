using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LTS.Cotacao.Application.Adapters.Services;
using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Ports.Repositories;
using Moq;

namespace LTS.Cotacao.Tests.Unit.Services
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturnCompanies()
        {
            var repo = new Mock<ICompanyRepository>();
            repo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new[]
            {
                new Company { Id = 1, Ticker = "PETR4", Name = "Petrobras PN" },
                new Company { Id = 2, Ticker = "VALE3", Name = "Vale ON" }
            });


            var svc = new CompanyService(repo.Object);


            var list = await svc.GetAllAsync();
            list.Should().HaveCount(2)
            .And.ContainSingle(c => c.Ticker == "PETR4");
            repo.Verify(r => r.GetAllAsync(), Times.Once);
        }


        [Fact]
        public async Task CreateAsync_ShouldReturnNewId_AndCallRepo()
        {
            var repo = new Mock<ICompanyRepository>();
            repo.Setup(r => r.CreateAsync(It.IsAny<Company>())).ReturnsAsync(42);
            var svc = new CompanyService(repo.Object);


            var id = await svc.CreateAsync(new CompanyDto { Ticker = "TEST3", Name = "Teste" });
            id.Should().Be(42);
            repo.Verify(r => r.CreateAsync(It.Is<Company>(c => c.Ticker == "TEST3")), Times.Once);
        }

    }
}
