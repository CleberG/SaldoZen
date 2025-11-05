using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Enun;

namespace SaldoZen.Aplicacao.Commands.InsertPlanoContas
{
    public class InsertPlanoContasCommand : IRequest<ResultViewModel>
    {
        public ETipoPlano Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
