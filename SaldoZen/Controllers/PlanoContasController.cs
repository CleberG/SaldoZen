using Microsoft.AspNetCore.Mvc;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Model;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoContasController : Controller
    {
        private readonly IRepositoryBase<PlanoContas> _repository;

        public PlanoContasController(IRepositoryBase<PlanoContas> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<PlanoContas>> GetAll()
        {
            var query = await _repository.GetAllAsync(); 
            return query.ToList();
        }
    }
}
