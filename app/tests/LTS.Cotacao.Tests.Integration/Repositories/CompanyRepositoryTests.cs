using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LTS.Cotacao.Infrastructure.Adapters.Repositories;
using LTS.Cotacao.Infrastructure.Data.Context;
using LTS.Cotacao.Tests.Integration.Infra;

namespace LTS.Cotacao.Tests.Integration.Repositories
{
    public class CompanyRepositoryTests : IClassFixture<MySqlContainerFixture>
    {
        private readonly string _cs;
        public CompanyRepositoryTests(MySqlContainerFixture fx)
        {
            _cs = fx.ConnectionString;
            DapperTypeHandlersTestInit.Ensure();
        }


        [Fact]
        public async Task Should_Insert_And_Get_ById()
        {
            var ctx = new DapperContext(_cs);
            var repo = new CompanyRepository(ctx);


            var id = await repo.CreateAsync(new Domain.Entities.Company { Ticker = "TEST3", Name = "Empresa Teste" });
            object value = id.Should().BeGreaterThan(0);


            var loaded = await repo.GetByIdAsync(id);
            loaded.Should().NotBeNull();
            loaded!.Ticker.Should().Be("TEST3");


            // cleanup
            (await repo.DeleteAsync(id)).Should().BeTrue();
        }


        [Fact]
        public async Task Should_List_Seeded_Companies()
        {
            var ctx = new DapperContext(_cs);
            var repo = new CompanyRepository(ctx);
            var all = await repo.GetAllAsync();
            all.Should().NotBeEmpty();
        }
    }
}
