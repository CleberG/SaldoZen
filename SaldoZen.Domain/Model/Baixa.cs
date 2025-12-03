using System;

namespace SaldoZen.Domain.Model
{
    /// <summary>
    /// Representa um pagamento ou recebimento (baixa) vinculado a uma previsão.
    /// </summary>
    public class Baixa : EntityBase
    {
        /// <summary>
        /// Valor final da baixa (calculado).
        /// </summary>
        public decimal ValorTotal { get; private set; }

        /// <summary>
        /// Data em que a baixa foi realizada.
        /// </summary>
        public DateTime DataBaixa { get; private set; }

        /// <summary>
        /// Referência à previsão à qual esta baixa está vinculada.
        /// </summary>
        public int PrevisaoId { get; private set; }

        public Previsao Previsao { get; private set; }

        /// <summary>
        /// Valor original desta baixa, sem acréscimos ou descontos.
        /// </summary>
        public decimal ValorOriginal { get; private set; }

        /// <summary>
        /// Valor dos juros aplicados a esta baixa.
        /// </summary>
        public decimal Juros { get; private set; } = 0;

        /// <summary>
        /// Valor da multa aplicada a esta baixa.
        /// </summary>
        public decimal Multa { get; private set; } = 0;

        /// <summary>
        /// Valor do desconto aplicado a esta baixa.
        /// </summary>
        public decimal Desconto { get; private set; } = 0;

        // EF Core constructor
        private Baixa() { }

        public Baixa(int previsaoId, DateTime dataBaixa, decimal valorOriginal, decimal juros = 0, decimal multa = 0, decimal desconto = 0)
        {
            PrevisaoId = previsaoId;
            DataBaixa = dataBaixa;
            ValorOriginal = valorOriginal;
            Juros = juros;
            Multa = multa;
            Desconto = desconto;

            CalcularTotal();
        }

        public void CalcularTotal()
        {
            ValorTotal = ValorOriginal + Juros + Multa - Desconto;
        }
    }
}
