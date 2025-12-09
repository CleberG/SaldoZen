using System;
using System.Collections.Generic;

namespace SaldoZen.McpServer.DTOs
{
    public class PrevisaoResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacoes { get; set; }
        public StatusResponse Status { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorOrcado { get; set; }
        public decimal ValorRealizado { get; set; }
        public List<BaixaResponse> Baixas { get; set; }
    }
}
