using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public Company ConvertToEntity()
        {
            var entity = new Company
            {
                Id = this.Id,
                Ticker = this.Ticker,
                Name = this.Name
            };

            return entity;
        }
        public static Company ConvertToEntity(CompanyDto dto)
        {
            var entity = new Company
            {
                Id = dto.Id,
                Ticker = dto.Ticker,
                Name = dto.Name
            };

            return entity;
        }
        public static List<Company> ConvertToEntityCollection(List<CompanyDto> dtos)
        {
            var entityList = new List<Company>();

            foreach (CompanyDto dto in dtos)
            {
                var entity = ConvertToEntity(dto);
                entityList.Add(entity);
            }

            return entityList;
        }
    }

}
