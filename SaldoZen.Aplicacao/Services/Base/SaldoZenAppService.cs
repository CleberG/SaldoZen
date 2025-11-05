using SaldoZen.Aplicacao.Dtos.Base;
using SaldoZen.Aplicacao.Interfaces;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Aplicacao.Services.Base
{
    public class SaldoZenAppService<T> : ISaldoZenAppService<T> where T : EntityBase
    {
        protected readonly IRepositoryBase<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        public Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAll(IEnumerable<int> id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResult>> GetAll<TResult>(CancellationToken cancellationToken = default) where TResult : BaseDto
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetById<TResult>(int id, CancellationToken cancellationToke) where TResult : BaseDto
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Insert<TResult>(TResult dto, CancellationToken cancellationToken) where TResult : BaseDto
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Update<TResult>(TResult dto, CancellationToken cancellationToken) where TResult : BaseDto
        {
            throw new NotImplementedException();
        }

        public Task<TResult> UpdateProps<TResult, TProp>(TResult dto, CancellationToken cancellationToken, params Expression<Func<T, TProp>>[] prop)
            where TResult : class
            where TProp : notnull
        {
            throw new NotImplementedException();
        }
    }
}
