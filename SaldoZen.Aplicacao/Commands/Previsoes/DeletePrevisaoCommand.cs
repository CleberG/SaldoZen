using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;

namespace SaldoZen.Aplicacao.Commands.Previsoes
{
    public class DeletePrevisaoCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
    }
}
