using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaldoZen.Aplicacao.Commands.Previsoes;
using SaldoZen.Aplicacao.Queries.Previsoes;
using System.Threading.Tasks;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/previsoes")]
    [Authorize]
    public class PrevisaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrevisaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPrevisoesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPrevisaoByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePrevisaoCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePrevisaoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("O Id da rota não corresponde ao Id do corpo da requisição.");
            }
            
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePrevisaoCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result);
        }

        [HttpPost("{previsaoId}/baixas")]
        public async Task<IActionResult> AddBaixa(int previsaoId, AddBaixaCommand command)
        {
            if (previsaoId != command.PrevisaoId)
            {
                return BadRequest("O Id da previsão na rota não corresponde ao do corpo da requisição.");
            }

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
