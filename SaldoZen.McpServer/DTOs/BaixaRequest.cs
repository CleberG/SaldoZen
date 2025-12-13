using System;

namespace SaldoZen.McpServer.DTOs
{
    public class BaixaRequest
    {
        public int PrevisaoId { get; set; }
        public DateTime DataBaixa { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
    }
}
