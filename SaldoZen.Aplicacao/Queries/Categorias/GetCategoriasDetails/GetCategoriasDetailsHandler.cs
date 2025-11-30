using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasDetails
{
    public class GetCategoriasDetailsHandler : IRequestHandler<GetCategoriasDetailsQuery, ResultViewModel<CategoriasDto>>
    {
        private readonly ICategoriaRepository _planoContasRepository;

        public GetCategoriasDetailsHandler(ICategoriaRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<CategoriasDto>> Handle(GetCategoriasDetailsQuery request, CancellationToken cancellationToken)
        {
            var planoContas = await _planoContasRepository.GetByIdAsync(request.Id);

            if (planoContas == null)
            {
                return ResultViewModel<CategoriasDto>.Error("Plano de contas não encontrado.");
            }
            var planoContasDto = CategoriasDto.FromEntity(planoContas);
            
            return ResultViewModel<CategoriasDto>.Success(planoContasDto);
        }
    }
}
