using System;
using System.Linq;
using FWS.Dao.Context;
using FWS.Ent.Crew;
using FWS.Log;

namespace FWS.Dao.Crew
{
    public class dUserInfo : dBaseGen<eUserInfo, FwsCrewContext>
    {
        public dUserInfo()
            : base()
        {
        }

        public override IQueryable<eUserInfo> ListarRegistrosComFiltro(eUserInfo filtro)
        {
            try
            {
                var query = dbSet.AsQueryable();

                if (filtro == null)
                    return query.OrderBy(p => p.userId);

                if (filtro.userId > 0)
                    query = query.Where(p => p.userId == filtro.userId).AsQueryable();

                if (!string.IsNullOrEmpty(filtro.memberId))
                    query = query.Where(p => p.memberId == filtro.memberId).AsQueryable();

                if (!string.IsNullOrEmpty(filtro.nome))
                    query = query.Where(p => p.nome == filtro.nome).AsQueryable();

                query = query.OrderBy(p => p.userId);
                return query;
            }
            catch (Exception ex)
            {
                appLog.LogMe(erro.Critical, ex, GetType(), "");
                throw;
            }
        }
    }



    //public class dUserInfo
    //{
    //    private readonly DbSet _dbSet;
    //    private readonly FwsCrewContext _dbContext;  

    //    public dUserInfo()
    //    {
    //        _dbContext = new FwsCrewContext();
    //        _dbSet = _dbContext.Set<eUserInfo>();
    //    }

    //    public eMensagem Incuir(eUserInfo item)
    //    {
    //        try
    //        {
    //            _dbSet.Add(item);
    //            _dbContext.SaveChanges();
    //            return hRetorno.Retorno();
    //        }
    //        catch (Exception ex)
    //        {
    //            appLog.LogMe(erro.Critical, ex, this.GetType(), mensagem: "");
    //            return hRetorno.Retorno(false, ex);
    //        }
    //    }
    //}
}
