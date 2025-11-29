using Microsoft.EntityFrameworkCore;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Model;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Repositories.Base;

namespace SaldoZen.Infraestrutura.Repositories.PlanoConta
{
    public class PlanoContasRepository : RepositoryBase<PlanoContas>, IPlanoContasRepository
    {
        public PlanoContasRepository(SaldoZenContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PlanoContas>> GetByDescriptionAsync(string descricao)
        {
            return await ListBy(pc => pc.Descricao.Contains(descricao))
                .ToListAsync();
        }
    }
}
