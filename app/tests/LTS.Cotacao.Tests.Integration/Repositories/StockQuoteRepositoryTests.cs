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
    public class StockQuoteRepositoryTests : IClassFixture<MySqlContainerFixture>
    {
        private readonly string _cs;
        public StockQuoteRepositoryTests(MySqlContainerFixture fx)
        {
            _cs = fx.ConnectionString;
            DapperTypeHandlersTestInit.Ensure();
        }


        [Fact]
        public async Task Should_Insert_And_Query_By_Range()
        {
            var ctx = new DapperContext(_cs);
            var repo = new StockQuoteRepository(ctx);


            var q = new Domain.Entities.StockQuote
            {
                CompanyId = 1,
                QuoteDate = new DateOnly(2025, 9, 1),
                Open = 10,
                High = 11,
                Low = 9,
                Close = 10.5m,
                Volume = 12345
            };
            var id = await repo.CreateAsync(q);
            id.Should().BeGreaterThan(0);


            var list = await repo.GetByCompanyAndRangeAsync(1, new DateOnly(2025, 9, 1), new DateOnly(2025, 9, 30));
            list.Should().ContainSingle(x => x.Id == id);


            // cleanup
            (await repo.DeleteAsync(id)).Should().BeTrue();
        }
    }
}
