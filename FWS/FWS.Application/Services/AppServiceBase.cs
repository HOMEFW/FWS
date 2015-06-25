using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FWS.Application.Interfaces;
using FWS.Domain.Interfaces.Services;

namespace FWS.Application.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _service = serviceBase;
        }



        public void Add(TEntity objeto)
        {
            _service.Add(objeto);
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public IList<TEntity> Find(Func<TEntity, bool> lista)
        {
            return _service.Find(lista);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public void Update(TEntity objeto)
        {
            _service.Update(objeto);
        }

        public void Remove(TEntity objeto)
        {
            _service.Remove(objeto);
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges(IDictionary<string, object> dicionario)
        {
            _service.SaveChanges(dicionario);
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _service.FindAsync(keyValues);
        }

        public Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return _service.FindAsync(cancellationToken, keyValues);
        }

        public Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary)
        {
            return _service.SaveChangesAsyn(cancellationToken, dictionary);

        }

        public Task<bool> DeleteAsync(params object[] keyValues)
        {
            return _service.DeleteAsync(keyValues);
        }

        public Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return _service.DeleteAsync(cancellationToken, keyValues);
        }
    }
}
