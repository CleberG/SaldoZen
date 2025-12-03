using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.Previsoes;

namespace SaldoZen.Aplicacao.Queries.Previsoes
{
    public class GetPrevisaoByIdQuery : IRequest<ResultViewModel<PrevisaoDto>>
    {
        public int Id { get; set; }
    }
}