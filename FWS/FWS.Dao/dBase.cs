using System;
using System.Data.Entity;
using System.Linq;
using FWS.Ent;
using FWS.Hlp;
using FWS.Log;

namespace FWS.Dao
{
    public interface IdBase<E> : IDisposable
    {
        E PesquisarPorID(int id);
        IQueryable<E> ListarTodos();
        IQueryable<E> ListarRegistrosComFiltro(E filtro);
        eMensagem Incluir(E item);
        eMensagem Remover(E item);
        eMensagem Atualizar(E item);
    }

    public abstract class dBaseGen<E, C> : IdBase<E>
        where E : class
        where C : DbContext, new()
    {
        private IQueryable<E> _validList;
        private DbSet<E> _dbSet;
        private readonly C _dbContext;

        protected DbSet<E> dbSet
        {
            get { return _dbSet ?? (_dbSet = _dbContext.Set<E>()); }
        }

        protected virtual IQueryable<E> validList
        {
            get
            {
                if (_validList == null)
                {
                    _validList = dbSet.Where(i => i != null);
                }
                return _validList;
            }
        }

        protected dBaseGen()
        {
            _dbContext = new C();
        }

        public virtual E PesquisarPorID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<E> ListarTodos()
        {
            return validList;
        }

        public abstract IQueryable<E> ListarRegistrosComFiltro(E filtro);

        public virtual eMensagem Incluir(E item)
        {
            try
            {
                dbSet.Add(item);
                _dbContext.SaveChanges();
                return hRetorno.Retorno();
            }
            catch (Exception ex)
            {
                appLog.LogMe(erro.Critical, ex, this.GetType(), "");
                return hRetorno.Retorno(false, ex);
            }
        }

        public virtual eMensagem Remover(E item)
        {
            try
            {
                dbSet.Remove(item);
                _dbContext.SaveChanges();
                return hRetorno.Retorno();
            }
            catch (Exception ex)
            {
                appLog.LogMe(erro.Critical, ex, this.GetType(), "");
                return hRetorno.Retorno(false, ex);
            }
        }

        public virtual eMensagem Atualizar(E item)
        {
            try
            {
                dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return hRetorno.Retorno();
            }
            catch (Exception ex)
            {
                appLog.LogMe(erro.Critical, ex, this.GetType(), "");
                return hRetorno.Retorno(false, ex);
            }
        }

        public virtual void Dispose()
        {
            _validList = null;
            _dbSet = null;
            _dbContext.Dispose();
        }
    }


    //public interface IDaoBase<TE> : IDisposable
    //{
    //    eMensagem Incluir(TE item);
    //    eMensagem Incluir(List<TE> lista);
    //    eMensagem Atualizar(TE item);
    //    eMensagem Atualizar(List<TE> lista);
    //    eMensagem Remover(TE item);
    //    eMensagem Remover(List<TE> item);
    //    IQueryable<TE> Listar();
    //}

    //public abstract class dBase<TE, TC> : IDaoBase<TE>
    //    where TE : class
    //    where TC : DbContext, new()
    //{
    //    private DbSet<TE> _dbSet;
    //    private readonly TC _dbContext;  

    //    protected dBase()
    //    {
    //        _dbContext = new TC();
    //    }

    //    protected DbSet<TE> dbSet
    //    {
    //        get { return _dbSet ?? (_dbSet = _dbContext.Set<TE>()); }
    //    }

    //    public virtual eMensagem Incluir(TE item)
    //    {
    //        try
    //        {
    //            dbSet.Add(item);
    //            _dbContext.SaveChanges();
    //            return hRetorno.Retorno();
    //        }
    //        catch (Exception ex)
    //        {
    //            appLog.LogMe(erro.Critical, ex, this.GetType(), "");
    //            return hRetorno.Retorno(false, ex);
    //        }
    //    }

    //    public virtual eMensagem Incluir(List<TE> lista)
    //    {
    //        //foreach (var retorno in lista.Select(Incluir)) 
    //        throw new NotImplementedException();    
    //    }

    //    public virtual eMensagem Atualizar(TE item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual eMensagem Atualizar(List<TE> lista)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual eMensagem Remover(TE item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual eMensagem Remover(List<TE> item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual IQueryable<TE> Listar()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
