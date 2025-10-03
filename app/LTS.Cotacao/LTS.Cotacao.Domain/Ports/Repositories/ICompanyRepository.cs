using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Entities;

namespace LTS.Cotacao.Domain.Ports.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<int> CreateAsync(Company c);
        Task<bool> UpdateAsync(Company c);
        Task<bool> DeleteAsync(int id);
    }
}
