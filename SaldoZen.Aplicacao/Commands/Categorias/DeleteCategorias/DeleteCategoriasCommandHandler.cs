using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Commands.Categorias.DeleteCategorias
{
    public class DeleteCategoriasCommandHandler : IRequestHandler<DeleteCategoriasCommand, ResultViewModel>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoriasCommandHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteCategoriasCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.Id);

            if (categoria == null)
            {
                return ResultViewModel.Error("Categoria não encontrada.");
            }

            _categoriaRepository.Remove(categoria);
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
