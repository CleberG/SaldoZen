using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.Previsoes;
using SaldoZen.Domain.Interfaces;

namespace SaldoZen.Aplicacao.Queries.Previsoes.Handlers
{
    public class GetPrevisaoByIdQueryHandler : IRequestHandler<GetPrevisaoByIdQuery, ResultViewModel<PrevisaoDto>>
    {
        private readonly IPrevisaoRepository _previsaoRepository;

        public GetPrevisaoByIdQueryHandler(IPrevisaoRepository previsaoRepository)
        {
            _previsaoRepository = previsaoRepository;
        }

        public async Task<ResultViewModel<PrevisaoDto>> Handle(GetPrevisaoByIdQuery request, CancellationToken cancellationToken)
        {
            var previsao = await _previsaoRepository.GetByIdWithIncludesAsync(request.Id);

            if (previsao == null)
            {
                return ResultViewModel<PrevisaoDto>.Error($"Previsão com o Id {request.Id} não foi encontrada.");
            }

            var previsaoDto = PrevisaoDto.FromEntity(previsao);
            
            return ResultViewModel<PrevisaoDto>.Success(previsaoDto);
        }
    }
}