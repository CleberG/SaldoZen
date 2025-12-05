using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;

namespace SaldoZen.Domain.Interfaces.PlanoConta
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<IEnumerable<Categoria>> GetByDescriptionAsync(string descricao);
    }
}

