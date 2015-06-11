using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FWS.Domain.Interfaces.Repositories;

namespace FWS.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        public void Add(TEntity objeto)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Find(Func<TEntity, bool> lista)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity objeto)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity objeto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(IDictionary<string, object> dicionario)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsyn(System.Threading.CancellationToken cancellationToken, IDictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}
