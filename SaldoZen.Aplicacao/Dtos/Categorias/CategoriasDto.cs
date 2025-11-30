using SaldoZen.Domain.Model;

namespace SaldoZen.Aplicacao.Dtos.PlanosContas
{
    public class CategoriasDto
    {
        public int Id { get; set; }

        public Tipo Tipo { get; set; }

        public string Descricao { get; set; }

        public CategoriasDto(int id, Tipo tipo, string descricao)
        {
            Id = id;
            Tipo = tipo;
            Descricao = descricao;
        }

        public static CategoriasDto FromEntity(Categoria planoContas)
        {
            return new CategoriasDto(
                planoContas.Id,
                new Tipo
                {
                    Valor = (int)planoContas.Tipo,
                    Descricao = planoContas.Tipo.ToString()
                },
                planoContas.Descricao
            );
        }
    }
}
