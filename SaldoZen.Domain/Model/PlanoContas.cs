using SaldoZen.Domain.Enun;

namespace SaldoZen.Domain.Model
{
    /// <summary>
    /// Classe resposável por definir o tipo se vai ser receita ou despesa para categorização.
    /// </summary>
    public class PlanoContas : EntityBase
    {
        public ETipoPlano Tipo { get; set; }

        public string Descricao { get; set; }

        private PlanoContas()
        {
        }

        public PlanoContas(ETipoPlano tipo, string descricao)
        {
            Tipo = tipo;
            Descricao = descricao;
        }
    }
}
