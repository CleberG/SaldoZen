using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetAllCategorias
{
    public class GetAllCategoriasHandler : IRequestHandler<GetAllCategoriasQuery, ResultViewModel<List<CategoriasDto>>>
    {
        private readonly ICategoriaRepository _planoContasRepository;

        public GetAllCategoriasHandler(ICategoriaRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<List<CategoriasDto>>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            var planosContas = await _planoContasRepository.GetAllAsync();

            var dtos = planosContas.Select(CategoriasDto.FromEntity).ToList();

            return  ResultViewModel<List<CategoriasDto>>.Success(dtos);
        }
    }
}
