using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<ResultViewModel<List<CategoriasDto>>>
    {
    }
}
