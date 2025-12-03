using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.Previsoes;

namespace SaldoZen.Aplicacao.Queries.Previsoes
{
    public class GetAllPrevisoesQuery : IRequest<ResultViewModel<List<PrevisaoDto>>>
    {
        // We can add pagination parameters here later if needed
    }
}