using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetPlanoContasPorDescricao
{
    public class GetPlanoContasPorDescricaoQuery : IRequest<ResultViewModel<List<PlanoContasDto>>>
    {
        public string Descricao { get; set; }

        public GetPlanoContasPorDescricaoQuery(string descricao)
        {
            Descricao = descricao;
        }
    }
}
