using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Domain.Interfaces.PlanoConta
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<IEnumerable<Categoria>> GetByDescriptionAsync(string descricao);
    }
}

