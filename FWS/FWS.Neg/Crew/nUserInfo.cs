using FWS.Dao.Crew;
using FWS.Ent.Crew;

namespace FWS.Neg.Crew
{
    public class nUserInfo : nBaseGen<eUserInfo>
    {
        public nUserInfo()
            : base()
        {
            dao = new dUserInfo();
        }

    }

}
