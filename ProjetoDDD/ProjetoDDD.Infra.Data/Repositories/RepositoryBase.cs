using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class 
    {
        protected ProjetoModeloContext Db =  new ProjetoModeloContext();
        private DbTransaction _transaction;
        private bool _disposed;

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public IList<TEntity> Find(Func<TEntity, bool> f)
        {
            return Db.Set<TEntity>().Where(f).ToList();
        }


        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void BeginTransaction()
        {
            if (Db.Database.Connection.State != ConnectionState.Open)
                Db.Database.Connection.Open();

            _transaction = Db.Database.Connection.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void SaveChanges(IDictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                try
                {
                    if (Db.Database != null && Db.Database.Connection.State == ConnectionState.Open)
                    {
                        Db.Database.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }

                if (Db != null)
                {
                    Db.Dispose();
                    Db = null;
                }
            }
            // release any unmanaged objects
            // set the object references to null
            _disposed = true;
        }
    }
}
