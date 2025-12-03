using MediatR;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Model;
using SaldoZen.Aplicacao.Dtos.Comuns;
using System.Threading;
using System.Threading.Tasks;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Interfaces.Base;

namespace SaldoZen.Aplicacao.Commands.Previsoes.Handlers
{
    public class CreatePrevisaoHandler : IRequestHandler<CreatePrevisaoCommand, ResultViewModel<Previsao>>
    {
        private readonly IPrevisaoRepository _previsaoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePrevisaoHandler(IPrevisaoRepository previsaoRepository, ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _previsaoRepository = previsaoRepository;
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Previsao>> Handle(CreatePrevisaoCommand request, CancellationToken cancellationToken)
        {
            // Basic validation
            if (request == null)
                return ResultViewModel<Previsao>.Error("Requisição inválida.");

            var categoria = await _categoriaRepository.GetByIdAsync(request.CategoriaId);
            if (categoria == null)
            {
                return ResultViewModel<Previsao>.Error($"Categoria com o Id {request.CategoriaId} não foi encontrada.");
            }

            var previsao = new Previsao(
                request.Descricao,
                request.ValorOriginal,
                request.DataVencimento,
                request.CategoriaId,
                request.Observacoes
            );

            await _previsaoRepository.AddAsync(previsao);
            await _unitOfWork.CommitAsync();

            return ResultViewModel<Previsao>.Success(previsao);
        }
    }
}

