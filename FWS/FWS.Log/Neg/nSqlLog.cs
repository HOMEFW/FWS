using System.Configuration.Provider;
using FWS.Log.Ent;
using FWS.Log.Dao;

namespace FWS.Log.Neg
{
    public class nSqlLog : ProviderBase
    {
        internal static eRetorno DoLog(eConfig config, eLog log)
        {
            return new dLog().GravaLog(config, log);
        }
    }
}
