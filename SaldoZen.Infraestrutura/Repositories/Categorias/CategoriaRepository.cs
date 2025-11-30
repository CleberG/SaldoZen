using Microsoft.EntityFrameworkCore;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Model;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Repositories.Base;

namespace SaldoZen.Infraestrutura.Repositories.Categorias
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SaldoZenContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Categoria>> GetByDescriptionAsync(string descricao)
        {
            return await ListBy(pc => pc.Descricao.Contains(descricao))
                .ToListAsync();
        }
    }
}
