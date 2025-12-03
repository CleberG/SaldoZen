using SaldoZen.Domain.Model;
using System;

namespace SaldoZen.Aplicacao.Dtos.Previsoes
{
    public class BaixaDto
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataBaixa { get; set; }
        public int PrevisaoId { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }


        public static BaixaDto FromEntity(Baixa baixa)
        {
            return new BaixaDto
            {
                Id = baixa.Id,
                ValorTotal = baixa.ValorTotal,
                DataBaixa = baixa.DataBaixa,
                PrevisaoId = baixa.PrevisaoId,
                ValorOriginal = baixa.ValorOriginal,
                Juros = baixa.Juros,
                Multa = baixa.Multa,
                Desconto = baixa.Desconto
            };
        }
    }
}
