using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Ports.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<int> CreateAsync(CompanyDto c);
        Task<bool> UpdateAsync(CompanyDto c);
        Task<bool> DeleteAsync(int id);
    }
}
