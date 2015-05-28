using System;
using System.Collections.Generic;

namespace ProjetoDDD.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IList<TEntity> Find(Func<TEntity, bool> f);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void remove(TEntity obj);
        void Dispose();
    }
}
