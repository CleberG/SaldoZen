using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;

namespace SaldoZen.Aplicacao.Queries.PlanosContas.GetPlanoContasDetails
{
    public class GetPlanoContasDetailsQuery : IRequest<ResultViewModel<PlanoContasDto>>
    {
        public int Id { get; set; }

        public GetPlanoContasDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
