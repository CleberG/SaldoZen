using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.Previsoes;
using SaldoZen.Domain.Interfaces;

namespace SaldoZen.Aplicacao.Queries.Previsoes.Handlers
{
    public class GetAllPrevisoesQueryHandler : IRequestHandler<GetAllPrevisoesQuery, ResultViewModel<List<PrevisaoDto>>>
    {
        private readonly IPrevisaoRepository _previsaoRepository;

        public GetAllPrevisoesQueryHandler(IPrevisaoRepository previsaoRepository)
        {
            _previsaoRepository = previsaoRepository;
        }

        public async Task<ResultViewModel<List<PrevisaoDto>>> Handle(GetAllPrevisoesQuery request, CancellationToken cancellationToken)
        {
            var previsoes = await _previsaoRepository.GetAllWithIncludesAsync();

            var previsoesDto = previsoes.Select(p => PrevisaoDto.FromEntity(p)).ToList();
            
            return ResultViewModel<List<PrevisaoDto>>.Success(previsoesDto);
        }
    }
}