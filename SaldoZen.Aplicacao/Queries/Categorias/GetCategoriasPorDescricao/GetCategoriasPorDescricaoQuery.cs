using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasPorDescricao
{
    public class GetCategoriasPorDescricaoQuery : IRequest<ResultViewModel<List<CategoriasDto>>>
    {
        public string Descricao { get; set; }

        public GetCategoriasPorDescricaoQuery(string descricao)
        {
            Descricao = descricao;
        }
    }
}
