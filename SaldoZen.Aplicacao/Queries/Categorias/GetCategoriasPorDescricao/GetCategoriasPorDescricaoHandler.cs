using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Aplicacao.Dtos.PlanosContas;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Queries.Categorias.GetCategoriasPorDescricao
{
    public class GetCategoriasPorDescricaoHandler : IRequestHandler<GetCategoriasPorDescricaoQuery, ResultViewModel<List<CategoriasDto>>>
    {
        private readonly ICategoriaRepository _planoContasRepository;

        public GetCategoriasPorDescricaoHandler(ICategoriaRepository planoContasRepository)
        {
            _planoContasRepository = planoContasRepository;
        }

        public async Task<ResultViewModel<List<CategoriasDto>>> Handle(GetCategoriasPorDescricaoQuery request, CancellationToken cancellationToken)
        {
            var planosContas = await _planoContasRepository.GetByDescriptionAsync(request.Descricao);

            var dtos = planosContas.Select(CategoriasDto.FromEntity).ToList();

            return  ResultViewModel<List<CategoriasDto>>.Success(dtos);
        }
    }
}
