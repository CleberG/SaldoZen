using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Model;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Repositories.Base;

namespace SaldoZen.Infraestrutura.Repositories
{
    public class BaixaRepository : RepositoryBase<Baixa>, IBaixaRepository
    {
        public BaixaRepository(SaldoZenContext context) : base(context)
        {
        }
    }
}
