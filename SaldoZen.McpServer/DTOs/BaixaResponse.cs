using System;

namespace SaldoZen.McpServer.DTOs
{
    public class BaixaResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
