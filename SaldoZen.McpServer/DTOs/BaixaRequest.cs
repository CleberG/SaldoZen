using System;

namespace SaldoZen.McpServer.DTOs
{
    public class BaixaRequest
    {
        public int PrevisaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
