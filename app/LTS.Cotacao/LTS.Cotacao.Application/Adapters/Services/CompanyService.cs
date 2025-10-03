using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Ports.Repositories;
using LTS.Cotacao.Domain.Ports.Services;

namespace LTS.Cotacao.Application.Adapters.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        public CompanyService(ICompanyRepository repo) => _repo = repo;
        public Task<IEnumerable<Company>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Company?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(CompanyDto c) => _repo.CreateAsync(c.ConvertToEntity());
        public Task<bool> UpdateAsync(CompanyDto c) => _repo.UpdateAsync(c.ConvertToEntity());
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}
