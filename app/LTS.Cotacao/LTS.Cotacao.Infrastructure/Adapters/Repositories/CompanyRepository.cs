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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _ctx;
        public CompanyRepository(DapperContext ctx) => _ctx = ctx;


        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlCompanyEnum.GetAll);
            return await conn.QueryAsync<Company>(sql);
        }


        public async Task<Company?> GetByIdAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlCompanyEnum.GetById);
            return await conn.QueryFirstOrDefaultAsync<Company>(sql, new { id });
        }


        public async Task<int> CreateAsync(Company c)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlCompanyEnum.Create);
            var id = await conn.ExecuteScalarAsync<int>(sql, c);
            return id;
        }


        public async Task<bool> UpdateAsync(Company c)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlCompanyEnum.Update);
            var rows = await conn.ExecuteAsync(sql, c);
            return rows > 0;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var sql = SqlManager.GetSql(SqlCompanyEnum.Delete);
            var rows = await conn.ExecuteAsync(sql, new { id });
            return rows > 0;
        }
    }
}
