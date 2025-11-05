using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Model;

namespace SaldoZen.Aplicacao.Commands.InsertPlanoContas
{
    public class InsertPlanoContasHandler : IRequestHandler<InsertPlanoContasCommand, ResultViewModel>
    {
        readonly IPlanoContasRepository _planoContasRepository;
        readonly IUnitOfWork _IUnitOfWork;

        public InsertPlanoContasHandler(IPlanoContasRepository planoContasRepository, IUnitOfWork iUnitOfWork)
        {
            _planoContasRepository = planoContasRepository;
            _IUnitOfWork = iUnitOfWork;
        }
        public async Task<ResultViewModel> Handle(InsertPlanoContasCommand request, CancellationToken cancellationToken)
        {
            var planoContas = new PlanoContas(request.Tipo,  request.Descricao);
            await _planoContasRepository.AddAsync(planoContas);
            await _IUnitOfWork.CommitAsync();
            return ResultViewModel.Success();
        }
    }
}
