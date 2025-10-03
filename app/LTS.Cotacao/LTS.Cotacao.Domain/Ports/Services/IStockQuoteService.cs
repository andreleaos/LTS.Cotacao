using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Ports.Services
{
    public interface IStockQuoteService
    {
        Task<IEnumerable<StockQuote>> GetByCompanyAndRangeAsync(int companyId, DateOnly? start, DateOnly? end);
        Task<long> CreateAsync(StockQuoteDto q);
        Task<bool> UpdateAsync(StockQuoteDto q);
        Task<bool> DeleteAsync(long id);
        Task<StockQuote?> GetByIdAsync(long id);
    }
}
