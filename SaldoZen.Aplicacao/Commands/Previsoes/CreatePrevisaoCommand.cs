using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Model;
using System;

namespace SaldoZen.Aplicacao.Commands.Previsoes
{
    public class CreatePrevisaoCommand : IRequest<ResultViewModel<Previsao>>
    {
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacoes { get; set; }
        public decimal ValorOriginal { get; set; }
    }
}
