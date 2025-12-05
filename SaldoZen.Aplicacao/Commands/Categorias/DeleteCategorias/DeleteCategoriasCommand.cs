using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;

namespace SaldoZen.Aplicacao.Commands.Categorias.DeleteCategorias
{
    public class DeleteCategoriasCommand : IRequest<ResultViewModel>
    {
        public DeleteCategoriasCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
