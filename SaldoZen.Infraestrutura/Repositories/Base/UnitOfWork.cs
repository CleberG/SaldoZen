using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Infraestrutura.Context;

namespace SaldoZen.Infraestrutura.Repositories.Base
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SaldoZenContext _contex;

        public UnitOfWork(SaldoZenContext contex)
        {
            _contex = contex;
        }

        public async Task<int> CommitAsync()
        {
           return await _contex.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contex.Dispose();
        }
    }
}
