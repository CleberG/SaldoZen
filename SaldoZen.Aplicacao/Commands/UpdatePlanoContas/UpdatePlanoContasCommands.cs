using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Enun;

namespace SaldoZen.Aplicacao.Commands.UpdatePlanoContas
{
    public class UpdatePlanoContasCommands : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public ETipoPlano Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
