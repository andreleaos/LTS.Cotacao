using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LTS.Cotacao.Api;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Tests.EndToEnd.Api
{
    public class CompaniesEndpointTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public CompaniesEndpointTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GET_companies_ShouldReturnOkAndList()
        {
            var client = _factory.CreateClient();
            var resp = await client.GetAsync("/api/companies/GetAll");
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            resp.Content.Headers.ContentType!.MediaType.Should().Be("application/json");


            var companies = await resp.Content.ReadFromJsonAsync<List<Company>>();
            companies.Should().NotBeNull();
            companies!.Count.Should().BeGreaterThan(0);
        }
    }

}
