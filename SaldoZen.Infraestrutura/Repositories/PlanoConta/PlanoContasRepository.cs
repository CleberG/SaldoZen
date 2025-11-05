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
    }
}
