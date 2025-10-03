using LTS.Cotacao.Domain.Dtos;
using LTS.Cotacao.Domain.Entities;
using LTS.Cotacao.Domain.Ports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTS.Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "Api de Cotacao de Ações";
        //}

        private readonly IStockQuoteService _service;
        public QuotesController(IStockQuoteService service) => _service = service;


        // GET /api/quotes?companyId=1&start=2025-09-01&end=2025-09-30
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<StockQuote>>> Get([FromQuery] int companyId, [FromQuery] DateOnly? start, [FromQuery] DateOnly? end)
        {
            if (companyId <= 0) return BadRequest("companyId is required");
            var list = await _service.GetByCompanyAndRangeAsync(companyId, start, end);
            return Ok(list);
        }


        [HttpGet("{id:long}")]
        [Produces("application/json")]
        public async Task<ActionResult<StockQuote>> GetById(long id)
        {
            try
            {
                var q = await _service.GetByIdAsync(id);
                return q is null ? NotFound() : Ok(q);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(StockQuoteDto q)
        {
            var id = await _service.CreateAsync(q);
            q.Id = id;
            return CreatedAtAction(nameof(GetById), new { id }, q);
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, StockQuoteDto q)
        {
            if (id != q.Id) return BadRequest("Id mismatch");
            var ok = await _service.UpdateAsync(q);
            return ok ? NoContent() : NotFound();
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
