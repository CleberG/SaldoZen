using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaldoZen.Aplicacao.Commands.InsertPlanoContas;
using SaldoZen.Aplicacao.Commands.UpdatePlanoContas;
using SaldoZen.Aplicacao.Queries.PlanosContas.GetAllPlanoContas;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoContasController : Controller
    {
        private readonly IRepositoryBase<PlanoContas> _repository;
        private readonly IMediator _mediator;

        public PlanoContasController(IRepositoryBase<PlanoContas> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertPlanoContasCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePlanoContasCommands command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPlanoContasQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<List<PlanoContas>> GetById()
        {
            var query = await _repository.GetAllAsync();
            return query.ToList();
        }

        [HttpGet("teste")]
        public async Task<string> GetTeste()
        {
            var query = await _repository.GetAllAsync();
            return "Cleber binitão";
        }
    }
}
