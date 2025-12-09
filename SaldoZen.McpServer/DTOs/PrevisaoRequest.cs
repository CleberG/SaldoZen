using System;

namespace SaldoZen.McpServer.DTOs
{
    public class PrevisaoRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int CategoriaId { get; set; }
        public int Status { get; set; }
        public string Observacoes { get; set; }
        public decimal ValorOriginal { get; set; }
    }
}
