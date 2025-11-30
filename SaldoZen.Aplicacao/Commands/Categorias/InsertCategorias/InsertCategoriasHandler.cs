using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Model;

namespace SaldoZen.Aplicacao.Commands.Categorias.InsertCategorias
{
    public class InsertCategoriasHandler : IRequestHandler<InsertCategoriasCommand, ResultViewModel>
    {
        readonly ICategoriaRepository _planoContasRepository;
        readonly IUnitOfWork _IUnitOfWork;

        public InsertCategoriasHandler(ICategoriaRepository planoContasRepository, IUnitOfWork iUnitOfWork)
        {
            _planoContasRepository = planoContasRepository;
            _IUnitOfWork = iUnitOfWork;
        }
        public async Task<ResultViewModel> Handle(InsertCategoriasCommand request, CancellationToken cancellationToken)
        {
            var planoContas = new Categoria(request.Tipo,  request.Descricao);
            await _planoContasRepository.AddAsync(planoContas);
            await _IUnitOfWork.CommitAsync();
            return ResultViewModel.Success();
        }
    }
}
