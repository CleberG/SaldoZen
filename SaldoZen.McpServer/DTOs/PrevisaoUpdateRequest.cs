using System;

namespace SaldoZen.McpServer.DTOs
{
    public class PrevisaoUpdateRequest
    {
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorOriginal { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
    }
}
