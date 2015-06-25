using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FWS.Domain.Interfaces.Repositories;
using FWS.Domain.Interfaces.Services;

namespace FWS.Domain.Services
{
    public class ServiceBase<TEntity>:IDisposable, IServiceBase<TEntity>  where TEntity:class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity objeto)
        {
            _repository.Add(objeto);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IList<TEntity> Find(Func<TEntity, bool> lista)
        {
            return _repository.Find(lista);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity objeto)
        {
            _repository.Update(objeto);
        }

        public void Remove(TEntity objeto)
        {
            _repository.Remove(objeto);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


        public void SaveChanges(IDictionary<string, object> dicionario)
        {
            _repository.SaveChanges(dicionario);
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _repository.FindAsync(keyValues);
        }

        public Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return _repository.FindAsync(cancellationToken, keyValues);
        }

        public Task<bool> SaveChangesAsyn(CancellationToken cancellationToken, IDictionary<string, object> dictionary)
        {
            return _repository.SaveChangesAsyn(cancellationToken, dictionary);
        }

        public Task<bool> DeleteAsync(params object[] keyValues)
        {
            return _repository.DeleteAsync(keyValues);
        }

        public Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return _repository.DeleteAsync(cancellationToken, keyValues);
        }
    }
}
