using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using FWS.Dao;
using FWS.Ent;

namespace FWS.Neg
{

    public interface IBase<E> : IDisposable
    {
        E PesquisarPorID(int id);
        IQueryable<E> ListarTodos();
        IQueryable<E> ListarRegistrosComFiltro(string palavra);
        eMensagem Incluir(E item);
        eMensagem Remover(E item);
        eMensagem Atualizar(E item);
    }

    public abstract class nBaseGen<E> : IDisposable, IBase<E> where E : class
    {
        public IdBase<E> dao;

        public nBaseGen()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            //dao = new D();
        }

        public virtual E PesquisarPorID(int id)
        {
            return dao.PesquisarPorID(id);
        }

        public virtual IQueryable<E> ListarTodos()
        {
            return dao.ListarTodos();//.OrderBy(i => i.ID);
        }

        public virtual IQueryable<E> ListarRegistrosComFiltro(E filtro)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            return dao.ListarRegistrosComFiltro(filtro);//.OrderBy(i => i.ID);
        }

        public virtual eMensagem Incluir(E item)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            return dao.Incluir(item);
        }

        public virtual eMensagem Remover(E item)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            return dao.Remover(item);
        }

        public virtual eMensagem Atualizar(E item)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
            return dao.Atualizar(item);
        }

        public virtual void Dispose()
        {
            dao.Dispose();
        }


        public IQueryable<E> ListarRegistrosComFiltro(string palavra)
        {
            throw new NotImplementedException();
        }
    }

    //public interface INegBase<E> : IDisposable
    //{
    //    eMensagem PesquisarPorID(int id);
    //    IQueryable<E> ListarTodos();
    //    IQueryable<E> ListarRegistrosComFiltro(string palavra);
    //    eMensagem Incluir(E item);
    //    void Remover(E item);
    //    eMensagem Atualizar(E item);
    //}

    //public abstract class NegBaseGen<E> : IDisposable, INegBase<E> where E : class
    //{
    //    public IDaoBase<E> dao;

    //    public NegBaseGen()
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //dao = new D();
    //    }

    //    public virtual eMensagem PesquisarPorID(int id)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.PesquisarPorID(id);
    //        return null;
    //    }

    //    public virtual IQueryable<E> ListarTodos()
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.ListarTodos();//.OrderBy(i => i.ID);
    //        return null;
    //    }

    //    public virtual IQueryable<E> ListarRegistrosComFiltro(string palavra)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.ListarRegistrosComFiltro(palavra);//.OrderBy(i => i.ID);
    //        return null;
    //    }

    //    public virtual eMensagem Incluir(E item)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        return dao.Incluir(item);
    //    }

    //    public void Remover(E item)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //dao.Remover(item);
    //    }

    //    public virtual eMensagem Atualizar(E item)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.Atualizar(item);
    //        return null;
    //    }

    //    public virtual void Dispose()
    //    {
    //        //dao.Dispose();
    //    }
    //}

    //public abstract class NegBase<E> : NegBaseGen<E>, INegBase<E> where E : class 
    //{
    //    public override IQueryable<E> ListarTodos()
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.ListarTodos().OrderBy(i => i.ID);
    //        return null;
    //    }

    //    public override IQueryable<E> ListarRegistrosComFiltro(string palavra)
    //    {
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
    //        //return dao.ListarRegistrosComFiltro(palavra).OrderBy(i => i.ID);
    //        return null;
    //    }
    //}
}
