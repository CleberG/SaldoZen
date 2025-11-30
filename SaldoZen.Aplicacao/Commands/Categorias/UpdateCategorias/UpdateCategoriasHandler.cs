using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Interfaces.PlanoConta;

namespace SaldoZen.Aplicacao.Commands.Categorias.UpdateCategorias
{
    public class UpdateCategoriasHandler : IRequestHandler<UpdateCategoriasCommands, ResultViewModel>
    {
        readonly ICategoriaRepository _planoContasRepository;
        readonly IUnitOfWork _IUnitOfWork;

        public UpdateCategoriasHandler(ICategoriaRepository planoContasRepository = null, IUnitOfWork iUnitOfWork = null)
        {
            _planoContasRepository = planoContasRepository;
            _IUnitOfWork = iUnitOfWork;
        }

        public async Task<ResultViewModel> Handle(UpdateCategoriasCommands request, CancellationToken cancellationToken)
        {
            var planoContas = await _planoContasRepository.GetByIdAsync(request.Id);
            if (planoContas == null)
                return ResultViewModel.Error("Plano de contas não encontrado.");

            planoContas.Update(request.Tipo, request.Descricao);
            _planoContasRepository.Update(planoContas);
            await _IUnitOfWork.CommitAsync();
            return ResultViewModel.Success();
        }
    }
}
