using SaldoZen.Domain.Model;

namespace SaldoZen.Aplicacao.Dtos.PlanosContas
{
    public class PlanoContasDto
    {
        public int Id { get; set; }

        public Tipo Tipo { get; set; }

        public string Descricao { get; set; }

        public PlanoContasDto(int id, Tipo tipo, string descricao)
        {
            Id = id;
            Tipo = tipo;
            Descricao = descricao;
        }

        public static PlanoContasDto FromEntity(PlanoContas planoContas)
        {
            return new PlanoContasDto(
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
