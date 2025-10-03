using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Enums;

namespace LTS.Cotacao.Infrastructure.Data.Queries
{
    public static class SqlManager
    {
        public static string GetSql(SqlCompanyEnum sqlCompanyEnum)
        {
            var sql = "";

            switch (sqlCompanyEnum)
            {
                case SqlCompanyEnum.GetAll:
                    sql = "SELECT Id, Ticker, Name FROM companies ORDER BY Ticker";
                    break;

                case SqlCompanyEnum.GetById:
                    sql = "SELECT Id, Ticker, Name FROM companies WHERE Id=@id";
                    break;

                case SqlCompanyEnum.Create:
                    sql = "INSERT INTO companies (Ticker, Name) VALUES (@Ticker, @Name); SELECT LAST_INSERT_ID();";
                    break;

                case SqlCompanyEnum.Update:
                    sql = "UPDATE companies SET Ticker=@Ticker, Name=@Name WHERE Id=@Id";
                    break;

                case SqlCompanyEnum.Delete:
                    sql = "DELETE FROM companies WHERE Id=@id";
                    break;

                default:
                    sql = "SELECT Id, Ticker, Name FROM companies ORDER BY Ticker";
                    break;
            }

            return sql;
        }

        public static string GetSql(SqlStockQuoteEnum sqlStockQuoteEnum)
        {
            var sql = "";

            switch (sqlStockQuoteEnum)
            {
                case SqlStockQuoteEnum.GetCompanyAndRange:
                    sql = @"SELECT Id, CompanyId, QuoteDate, Open, High, Low, Close, Volume
                            FROM stock_quotes
                            WHERE CompanyId = @companyId
                            AND (@start IS NULL OR QuoteDate >= @start)
                            AND (@end IS NULL OR QuoteDate <= @end)
                            ORDER BY QuoteDate";
                    break;

                case SqlStockQuoteEnum.GetById:
                    sql = @"SELECT Id, CompanyId, QuoteDate, Open, High, Low, Close, Volume
                            FROM stock_quotes WHERE Id=@id";
                    break;

                case SqlStockQuoteEnum.Create:
                    sql = @"INSERT INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
                            VALUES (@CompanyId, @QuoteDate, @Open, @High, @Low, @Close, @Volume);
                            SELECT LAST_INSERT_ID();";
                    break;

                case SqlStockQuoteEnum.Update:
                    sql = @"UPDATE stock_quotes
                            SET CompanyId=@CompanyId, QuoteDate=@QuoteDate, Open=@Open, High=@High, Low=@Low, Close=@Close, Volume=@Volume
                            WHERE Id=@Id";
                    break;

                case SqlStockQuoteEnum.Delete:
                    sql = "DELETE FROM stock_quotes WHERE Id=@id";
                    break;
            }

            return sql;
        }

    }

}
