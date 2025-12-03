using MediatR;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using System.Threading;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Commands.Previsoes.Handlers
{
    public class DeletePrevisaoHandler : IRequestHandler<DeletePrevisaoCommand, ResultViewModel>
    {
        private readonly IPrevisaoRepository _previsaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePrevisaoHandler(IPrevisaoRepository previsaoRepository, IUnitOfWork unitOfWork)
        {
            _previsaoRepository = previsaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeletePrevisaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultViewModel.Error("Requisição inválida.");

            var previsao = await _previsaoRepository.GetByIdAsync(request.Id);
            if (previsao == null)
            {
                // Return success even if not found, as the desired state is "doesn't exist".
                return ResultViewModel.Success();
            }
            
            _previsaoRepository.Remove(previsao);
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}