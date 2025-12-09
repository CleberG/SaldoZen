using SaldoZen.Domain.Enun;
using SaldoZen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaldoZen.Aplicacao.Dtos.Previsoes
{
    public class PrevisaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacoes { get; set; }
        public StatusDto Status { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorOrcado { get; set; }
        public decimal ValorRealizado { get; set; }
        public List<BaixaDto> Baixas { get; set; }

        public static PrevisaoDto FromEntity(Previsao previsao)
        {
            return new PrevisaoDto
            {
                Id = previsao.Id,
                Descricao = previsao.Descricao,
                CategoriaId = previsao.CategoriaId,
                // Assuming Categoria is loaded
                CategoriaDescricao = previsao.Categoria?.Descricao,
                DataVencimento = previsao.DataVencimento,
                Observacoes = previsao.Observacoes,
                Status = new StatusDto { Valor = (int)previsao.Status,  Descricao = previsao.Status.ToString() },
                ValorOriginal = previsao.ValorOriginal,
                ValorTotal = previsao.ValorTotal,
                Juros = previsao.Juros,
                Multa = previsao.Multa,
                Desconto = previsao.Desconto,
                ValorOrcado = previsao.ValorOrcado,
                ValorRealizado = previsao.ValorRealizado,
                // Assuming Baixas are loaded
                Baixas = previsao.Baixas?.Select(BaixaDto.FromEntity).ToList() ?? new List<BaixaDto>()
            };
        }
    }
}
