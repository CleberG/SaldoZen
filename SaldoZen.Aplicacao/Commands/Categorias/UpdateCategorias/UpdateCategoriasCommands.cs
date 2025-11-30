using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Enun;

namespace SaldoZen.Aplicacao.Commands.Categorias.UpdateCategorias
{
    public class UpdateCategoriasCommands : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public ETipoCategoria Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
