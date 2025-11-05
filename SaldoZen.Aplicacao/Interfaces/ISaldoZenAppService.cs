using SaldoZen.Aplicacao.Dtos.Base;
using SaldoZen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Interfaces
{
    public interface ISaldoZenAppService<TEntity> where TEntity : EntityBase
    {
        Task<TResult> Insert<TResult>(TResult dto, CancellationToken cancellationToken) where TResult : BaseDto;
        
        Task<TResult> Update<TResult>(TResult dto, CancellationToken cancellationToken) where TResult : BaseDto;
        
        Task<TResult> UpdateProps<TResult, TProp>(TResult dto, CancellationToken cancellationToken, params Expression<Func<TEntity, TProp>>[] prop) where TResult : class where TProp : notnull;
        
        Task<bool> Delete(int id, CancellationToken cancellationToken = default(CancellationToken));
        
        Task<bool> DeleteAll(IEnumerable<int> id, CancellationToken cancellationToken = default(CancellationToken));
        
        Task<TResult> GetById<TResult>(int id, CancellationToken cancellationToke) where TResult : BaseDto;

        Task<IEnumerable<TResult>> GetAll<TResult>(CancellationToken cancellationToken = default) where TResult : BaseDto;

        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken);
    }
}
