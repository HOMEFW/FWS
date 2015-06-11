using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FWS.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        #region Functions
        void Add(TEntity objeto);
        TEntity GetById(int id);
        IList<TEntity> Find(Func<TEntity, bool> lista);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity objeto);
        void Remove(TEntity objeto);
        void Dispose();
        #endregion Functions

        #region Transaction
        void SaveChanges(IDictionary<string, object> dicionario);
        #endregion Transaction

        #region Async
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        #endregion Async

    }
}
