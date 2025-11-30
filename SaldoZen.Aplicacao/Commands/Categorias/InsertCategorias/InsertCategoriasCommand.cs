using MediatR;
using SaldoZen.Aplicacao.Dtos.Comuns;
using SaldoZen.Domain.Enun;

namespace SaldoZen.Aplicacao.Commands.Categorias.InsertCategorias
{
    public class InsertCategoriasCommand : IRequest<ResultViewModel>
    {
        public ETipoCategoria Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
