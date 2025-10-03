using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Dtos
{
    public class StockQuoteDto
    {
        public long Id { get; set; }
        public int CompanyId { get; set; }
        public DateOnly QuoteDate { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        public StockQuote ConvertToEntity()
        {
            var entity = new StockQuote()
            {
                Id = this.Id,
                CompanyId = this.CompanyId,
                QuoteDate = this.QuoteDate,
                Open = this.Open,
                High = this.High,
                Low = this.Low,
                Close = this.Close,
                Volume = this.Volume
            };

            return entity;
        }

        public static StockQuote ConvertToEntity(StockQuoteDto dto)
        {
            var entity = new StockQuote()
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                QuoteDate = dto.QuoteDate,
                Open = dto.Open,
                High = dto.High,
                Low = dto.Low,
                Close = dto.Close,
                Volume = dto.Volume
            };

            return entity;
        }

        public static List<StockQuote> ConvertToEntityCollection(List<StockQuoteDto> dtos)
        {
            var entityList = new List<StockQuote>();

            foreach (var dto in dtos)
            {
                var entity = ConvertToEntity(dto);
                entityList.Add(entity);
            }

            return entityList;
        }
    }

}
