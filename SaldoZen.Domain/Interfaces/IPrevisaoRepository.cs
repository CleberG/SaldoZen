using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;

namespace SaldoZen.Domain.Interfaces
{
    public interface IPrevisaoRepository : IRepositoryBase<Previsao>
    {
        Task<Previsao> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<Previsao>> GetAllWithIncludesAsync();
    }
}



