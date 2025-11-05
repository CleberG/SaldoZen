using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetAllPlanoContas
{
    public class GetAllPlanoContasQuery : IRequest<ResultViewModel<List<PlanoContasDto>>>
    {
    }
}
