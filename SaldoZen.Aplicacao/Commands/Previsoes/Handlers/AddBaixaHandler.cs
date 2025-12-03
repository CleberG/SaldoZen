using MediatR;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Model;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Interfaces.Base;
using System.Threading;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Commands.Previsoes.Handlers
{
    public class AddBaixaHandler : IRequestHandler<AddBaixaCommand, ResultViewModel<Baixa>>
    {
        private readonly IPrevisaoRepository _previsaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddBaixaHandler(IPrevisaoRepository previsaoRepository, IUnitOfWork unitOfWork)
        {
            _previsaoRepository = previsaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Baixa>> Handle(AddBaixaCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultViewModel<Baixa>.Error("Requisição inválida.");

            var previsao = await _previsaoRepository.GetByIdWithIncludesAsync(request.PrevisaoId);
            if (previsao == null)
            {
                return ResultViewModel<Baixa>.Error($"Previsão com o Id {request.PrevisaoId} não foi encontrada.");
            }

            var baixa = new Baixa(
                request.PrevisaoId,
                request.DataBaixa,
                request.ValorOriginal,
                request.Juros,
                request.Multa,
                request.Desconto
            );
            
            previsao.AdicionarBaixa(baixa);
            
            _previsaoRepository.Update(previsao); 

            await _unitOfWork.CommitAsync();

            return ResultViewModel<Baixa>.Success(baixa);
        }
    }
}