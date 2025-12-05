using System;
using System.Collections.Generic;

namespace SaldoZen.McpServer.DTOs
{
    public class PrevisaoResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public CategoriasResponde Categoria { get; set; }
        public StatusResponse Status { get; set; }
        public IEnumerable<BaixaResponse> Baixas { get; set; }
        public decimal ValorPago { get; set; }
    }
}
