using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Dtos;

namespace LTS.Cotacao.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = string.Empty; // ex: PETR4
        public string Name { get; set; } = string.Empty; // ex: Petrobras PN

        public CompanyDto ConvertToDto()
        {
            var dto = new CompanyDto
            {
                Id = this.Id,
                Ticker = this.Ticker,
                Name = this.Name
            };

            return dto;
        }
        public static CompanyDto ConvertToDto(Company entity)
        {
            var dto = new CompanyDto
            {
                Id = entity.Id,
                Ticker = entity.Ticker,
                Name = entity.Name
            };

            return dto;
        }
        public static List<CompanyDto> ConvertToDtoCollection(List<Company> entities)
        {
            var dtoList = new List<CompanyDto>();

            foreach (Company entity in entities)
            {
                var dto = ConvertToDto(entity);
                dtoList.Add(dto);
            }

            return dtoList;
        }

        public void ValidateFields()
        {
            if(this.Ticker == null)
            {
                throw new ArgumentNullException("Campo Ticker precisa ser informado");
            }

            if (this.Name == null)
            {
                throw new ArgumentNullException("Campo Name precisa ser informado");
            }

        }

    }
}

