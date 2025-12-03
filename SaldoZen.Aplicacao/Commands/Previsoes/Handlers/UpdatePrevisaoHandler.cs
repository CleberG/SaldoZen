using MediatR;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Aplicacao.Dtos.Comuns;
using System.Threading;
using System.Threading.Tasks;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;

namespace SaldoZen.Aplicacao.Commands.Previsoes.Handlers
{
    public class UpdatePrevisaoHandler : IRequestHandler<UpdatePrevisaoCommand, ResultViewModel<Previsao>>
    {
        private readonly IPrevisaoRepository _previsaoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePrevisaoHandler(IPrevisaoRepository previsaoRepository, ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _previsaoRepository = previsaoRepository;
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Previsao>> Handle(UpdatePrevisaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultViewModel<Previsao>.Error("Requisição inválida.");

            var previsao = await _previsaoRepository.GetByIdAsync(request.Id);
            if (previsao == null)
            {
                return ResultViewModel<Previsao>.Error($"Previsão com o Id {request.Id} não foi encontrada.");
            }

            var categoria = await _categoriaRepository.GetByIdAsync(request.CategoriaId);
            if (categoria == null)
            {
                return ResultViewModel<Previsao>.Error($"Categoria com o Id {request.CategoriaId} não foi encontrada.");
            }

            previsao.UpdateInfo(
                request.Descricao,
                request.ValorOriginal,
                request.DataVencimento,
                request.CategoriaId,
                request.Observacoes,
                request.Juros,
                request.Multa,
                request.Desconto
            );

            _previsaoRepository.Update(previsao);
            await _unitOfWork.CommitAsync();

            return ResultViewModel<Previsao>.Success(previsao);
        }
    }
}