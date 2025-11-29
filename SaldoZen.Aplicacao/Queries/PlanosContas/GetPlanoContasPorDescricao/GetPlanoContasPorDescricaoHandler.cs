using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetPlanoContasPorDescricao
{
    public class GetPlanoContasPorDescricaoHandler : IRequestHandler<GetPlanoContasPorDescricaoQuery, ResultViewModel<List<PlanoContasDto>>>
    {
        private readonly IPlanoContasRepository _planoContasRepository;

        public GetPlanoContasPorDescricaoHandler(IPlanoContasRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<List<PlanoContasDto>>> Handle(GetPlanoContasPorDescricaoQuery request, CancellationToken cancellationToken)
        {
            var planosContas = await _planoContasRepository.GetByDescriptionAsync(request.Descricao);

            var dtos = planosContas.Select(PlanoContasDto.FromEntity).ToList();

            return  ResultViewModel<List<PlanoContasDto>>.Success(dtos);
        }
    }
}
