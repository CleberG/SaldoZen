using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Infraestrutura.Context;

namespace SaldoZen.Infraestrutura.Repositories.Base
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SaldoZenContext _context;

        public UnitOfWork(SaldoZenContext contex)
        {
            _context = contex;
        }

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
