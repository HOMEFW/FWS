using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IList<TEntity> Find(Func<TEntity, bool> f);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

        #region Transaction
        void SaveChanges(IDictionary<string, object> dictionary);
        #endregion

        #region Async
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        //Task<bool> DeleteAsync(params object[] keyValues);
        //Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary);
        #endregion
    }
}
