using SaldoZen.Domain.Enun;

namespace SaldoZen.Domain.Model
{
    /// <summary>
    /// Classe resposável por definir o tipo se vai ser receita ou despesa para categorização.
    /// </summary>
    public class Categoria : EntityBase
    {
        public ETipoCategoria Tipo { get; set; }

        public string Descricao { get; set; }

        private Categoria()
        {
        }

        public Categoria(ETipoCategoria tipo, string descricao)
        {
            Tipo = tipo;
            Descricao = descricao;
        }


        public void Update(ETipoCategoria tipo, string descricao)
        {
            Tipo = tipo;
            Descricao = descricao;
            AlteradoEm = DateTime.UtcNow;
        }
    }
}
