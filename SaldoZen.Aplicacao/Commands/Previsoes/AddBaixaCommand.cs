using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Model;
using System;

namespace SaldoZen.Aplicacao.Commands.Previsoes
{
    public class AddBaixaCommand : IRequest<ResultViewModel<Baixa>>
    {
        public int PrevisaoId { get; set; }
        public DateTime DataBaixa { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
    }
}