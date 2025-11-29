using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Domain.Interfaces.PlanoConta
{
    public interface IPlanoContasRepository : IRepositoryBase<PlanoContas>
    {
        Task<IEnumerable<PlanoContas>> GetByDescriptionAsync(string descricao);
    }
}
