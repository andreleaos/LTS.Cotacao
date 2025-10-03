using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Enums;
using LTS.Cotacao.Domain.Ports.Repositories;
using LTS.Cotacao.Infrastructure.Data.Context;
using LTS.Cotacao.Infrastructure.Data.Queries;

namespace LTS.Cotacao.Infrastructure.Adapters.Repositories
{
    public class StockQuoteRepository : IStockQuoteRepository
    {
        private readonly DapperContext _ctx;
        public StockQuoteRepository(DapperContext ctx) => _ctx = ctx;


        public async Task<IEnumerable<StockQuote>> GetByCompanyAndRangeAsync(int companyId, DateOnly? start, DateOnly? end)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlStockQuoteEnum.GetCompanyAndRange);

            try
            {
                return await conn.QueryAsync<StockQuote>(sql, new { companyId, start, end });
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar os dados para sotck quote: {ex.Message}");
            }

        }


        public async Task<long> CreateAsync(StockQuote q)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlStockQuoteEnum.Create);

            try
            {
                return await conn.ExecuteScalarAsync<long>(sql, q);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar os dados para sotck quote: {ex.Message}");
            }
        }


        public async Task<bool> UpdateAsync(StockQuote q)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlStockQuoteEnum.Update);

            try
            {
                var rows = await conn.ExecuteAsync(sql, q);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar os dados para sotck quote: {ex.Message}");
            }
        }


        public async Task<bool> DeleteAsync(long id)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlStockQuoteEnum.Delete);
            try
            {
                var rows = await conn.ExecuteAsync(sql, new { id });
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar os dados para sotck quote: {ex.Message}");
            }

        }


        public async Task<StockQuote?> GetByIdAsync(long id)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlStockQuoteEnum.GetById);
            try
            {
                return await conn.QueryFirstOrDefaultAsync<StockQuote>(sql, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar os dados para sotck quote: {ex.Message}");
            }
        }
    }
}
