﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FWS.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class 
    {
        void Add(TEntity objeto);
        TEntity GetById(int id);
        IList<TEntity> Find(Func<TEntity, bool> lista);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity objeto);
        void Remove(TEntity objeto);
        void Dispose();
        void SaveChanges(IDictionary<string, object> dicionario);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}