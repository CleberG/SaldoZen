using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaldoZen.Aplicacao.Commands.Categorias.DeleteCategorias;
using SaldoZen.Aplicacao.Commands.Categorias.InsertCategorias;
using SaldoZen.Aplicacao.Commands.Categorias.UpdateCategorias;
using SaldoZen.Aplicacao.Queries.Categorias.GetAllCategorias;
using SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasDetails;
using SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasPorDescricao;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : Controller
    {
        private readonly IRepositoryBase<Categoria> _repository;
        private readonly IMediator _mediator;

        public CategoriaController(IRepositoryBase<Categoria> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertCategoriasCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoriasCommands command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoriasCommand(id);
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
            var query = new GetAllCategoriasQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoriasDetailsQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("descricao")]
        public async Task<IActionResult> GetPlanoContasPorDescricao(string descricao)
        {
            var query = new GetCategoriasPorDescricaoQuery(descricao);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
       
    }
}
