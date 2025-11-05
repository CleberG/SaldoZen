using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetAllPlanoContas
{
    public class GetAllPlanoContasHandler : IRequestHandler<GetAllPlanoContasQuery, ResultViewModel<List<PlanoContasDto>>>
    {
        private readonly IPlanoContasRepository _planoContasRepository;

        public GetAllPlanoContasHandler(IPlanoContasRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<List<PlanoContasDto>>> Handle(GetAllPlanoContasQuery request, CancellationToken cancellationToken)
        {
            var planosContas = await _planoContasRepository.GetAllAsync();

            var dtos = planosContas.Select(PlanoContasDto.FromEntity).ToList();

            return  ResultViewModel<List<PlanoContasDto>>.Success(dtos);
        }
    }
}
