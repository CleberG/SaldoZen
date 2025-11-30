using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasDetails
{
    public class GetCategoriasDetailsQuery : IRequest<ResultViewModel<CategoriasDto>>
    {
        public int Id { get; set; }

        public GetCategoriasDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
