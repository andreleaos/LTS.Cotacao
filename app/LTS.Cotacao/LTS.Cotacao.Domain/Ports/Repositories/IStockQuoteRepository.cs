using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Ports.Repositories
{
    public interface IStockQuoteRepository
    {
        Task<IEnumerable<StockQuote>> GetByCompanyAndRangeAsync(int companyId, DateOnly? start, DateOnly? end);
        Task<long> CreateAsync(StockQuote q);
        Task<bool> UpdateAsync(StockQuote q);
        Task<bool> DeleteAsync(long id);
        Task<StockQuote?> GetByIdAsync(long id);
    }
}
