using SaldoZen.Domain.Enun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Domain.Model
{
    /// <summary>
    /// Classe que respresenta uma previsão financeira.
    /// Tanto para receitas(entradas) quanto para despesas(saídas).
    /// </summary> 
    public class Previsao : EntityBase
    {
        /// <summary>
        /// Descrição da previsão.
        /// </summary>
        public string Descricao { get; private set; }

        /// <summary>
        /// referencia à categoria da previsão.
        /// </summary>
        public int CategoriaId { get; private set; }

        public Categoria Categoria { get; set; }

        /// <summary>
        /// Refere-se à data de vencimento da previsão.
        /// </summary>
        public DateTime DataVencimento { get; private set; }

        /// <summary>
        /// Observações adicionais sobre a previsão.
        /// </summary>
        public string Observacoes { get; private set; }

        public EStatus Status { get; private set; }

        /// <summary>
        /// Valor original da previsão, sem acréscimos ou descontos.
        /// </summary>
        public decimal ValorOriginal { get; private set; }

        /// <summary>
        /// Valor total da previsão, incluindo juros, multa e descontos.
        /// </summary>
        public decimal ValorTotal { get; private set; }

        /// <summary>
        /// Valor dos juros aplicados à previsão.
        /// </summary>
        public decimal Juros { get; private set; } = 0;

        /// <summary>
        /// Valor da multa aplicada à previsão.
        /// </summary>
        public decimal Multa { get; private set; } = 0;

        /// <summary>
        /// Valor do desconto aplicado à previsão.
        /// </summary>
        public decimal Desconto { get; private set; } = 0;

        /// <summary>
        /// Valor orçado para a previsão, igual ao valor original, propriedade calculada.
        /// </summary>
        public decimal ValorOrcado { get; private set; }

        /// <summary>
        /// Valor realizado até o momento para a previsão. prioriedade calculada baseada no valor total.
        /// </summary>
        public decimal ValorRealizado { get; private set; }

        public ICollection<Baixa> Baixas { get; private set; }


        private Previsao() 
        {
            Baixas = new List<Baixa>();
        }

        public Previsao(string descricao, decimal valorOriginal, DateTime dataVencimento, int categoriaId, string observacoes = null)
        {
            Descricao = descricao;
            ValorOriginal = valorOriginal;
            ValorOrcado = valorOriginal;
            DataVencimento = dataVencimento;
            CategoriaId = categoriaId;
            Observacoes = observacoes;
            Status = EStatus.EmAberto;
            Baixas = new List<Baixa>();

            CalcularTotal();
        }

        public void UpdateInfo(string descricao, decimal valorOriginal, DateTime dataVencimento, int categoriaId, string observacoes, decimal juros, decimal multa, decimal desconto)
        {
            Descricao = descricao;
            ValorOriginal = valorOriginal;
            ValorOrcado = valorOriginal;
            DataVencimento = dataVencimento;
            CategoriaId = categoriaId;
            Observacoes = observacoes;
            Juros = juros;
            Multa = multa;
            Desconto = desconto;

            CalcularTotal();
            AtualizarStatus();
        }

        public void CalcularTotal()
        {
            ValorTotal = ValorOriginal + Juros + Multa - Desconto;
        }


        public void AdicionarBaixa(Baixa baixa)
        {
            Baixas.Add(baixa);
            CalcularValorRealizado();
        }

        public void CalcularValorRealizado()
        {
            ValorRealizado = Baixas.Sum(b => b.ValorTotal);
            AtualizarStatus();
        }

        private void AtualizarStatus()
        {
            if (ValorRealizado >= ValorTotal)
            {
                Status = EStatus.Pago;
            }
            else if (ValorRealizado > 0 && ValorRealizado < ValorTotal)
            {
                Status = EStatus.Parcial;
            }
            else
            {
                Status = EStatus.EmAberto;
            }
        }

    }
}
