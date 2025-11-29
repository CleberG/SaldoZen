using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetPlanoContasDetails
{
    public class GetPlanoContasDetailsHandler : IRequestHandler<GetPlanoContasDetailsQuery, ResultViewModel<PlanoContasDto>>
    {
        private readonly IPlanoContasRepository _planoContasRepository;

        public GetPlanoContasDetailsHandler(IPlanoContasRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<PlanoContasDto>> Handle(GetPlanoContasDetailsQuery request, CancellationToken cancellationToken)
        {
            var planoContas = await _planoContasRepository.GetByIdAsync(request.Id);

            if (planoContas == null)
            {
                return ResultViewModel<PlanoContasDto>.Error("Plano de contas não encontrado.");
            }
            var planoContasDto = PlanoContasDto.FromEntity(planoContas);
            
            return ResultViewModel<PlanoContasDto>.Success(planoContasDto);
        }
    }
}
