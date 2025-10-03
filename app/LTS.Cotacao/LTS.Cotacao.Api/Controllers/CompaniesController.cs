using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Ports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTS.Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Api de Gestão de Empresas listas em Bolsa";
        }

        private readonly ICompanyService _service;
        public CompaniesController(ICompanyService service) => _service = service;


        [HttpGet]
        [Route("GetAll")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            IEnumerable<Company> companies = await _service.GetAllAsync();
            return companies is null ? NotFound() : Ok(companies);

        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            var c = await _service.GetByIdAsync(id);
            return c is null ? NotFound() : Ok(c);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CompanyDto c)
        {
            var id = await _service.CreateAsync(c);
            c.Id = id;
            return CreatedAtAction(nameof(GetById), new { id }, c);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CompanyDto c)
        {
            if (id != c.Id) return BadRequest("Id mismatch");
            var ok = await _service.UpdateAsync(c);
            return ok ? NoContent() : NotFound();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
