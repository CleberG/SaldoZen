namespace SaldoZen.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
