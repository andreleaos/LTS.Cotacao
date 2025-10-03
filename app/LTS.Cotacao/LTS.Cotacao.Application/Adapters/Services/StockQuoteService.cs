using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Ports.Repositories;
using LTS.Cotacao.Domain.Ports.Services;

namespace LTS.Cotacao.Application.Adapters.Services
{
    public class StockQuoteService : IStockQuoteService
    {
        private readonly IStockQuoteRepository _repo;
        public StockQuoteService(IStockQuoteRepository repo) => _repo = repo;

        public Task<IEnumerable<StockQuote>> GetByCompanyAndRangeAsync(int companyId, DateOnly? start, DateOnly? end)
        => _repo.GetByCompanyAndRangeAsync(companyId, start, end);


        public Task<long> CreateAsync(StockQuoteDto q) => _repo.CreateAsync(q.ConvertToEntity());
        public Task<bool> UpdateAsync(StockQuoteDto q) => _repo.UpdateAsync(q.ConvertToEntity());
        public Task<bool> DeleteAsync(long id) => _repo.DeleteAsync(id);
        public Task<StockQuote?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);
    }

}
