using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AkademikDanismanlarManager : IAkademikDanismanlarService
    {
        IAkademikDanismanlarDAL _akademikDanismanlarDAL;

        public AkademikDanismanlarManager(IAkademikDanismanlarDAL akademikDanismanlarDAL)
        {
            _akademikDanismanlarDAL=akademikDanismanlarDAL;
        }

        public void AkademikDanismanAdd(AkademikDanismanlarTbl akademikDanismanlarTbl)
        {
            _akademikDanismanlarDAL.Insert(akademikDanismanlarTbl);
        }

        public void AkademikDanismanDelete(AkademikDanismanlarTbl akademikDanismanlarTbl)
        {
            _akademikDanismanlarDAL.Delete(akademikDanismanlarTbl);
        }

        public void AkademikDanismanUpdate(AkademikDanismanlarTbl akademikDanismanlarTbl)
        {
            _akademikDanismanlarDAL.Update(akademikDanismanlarTbl);
        }

        public AkademikDanismanlarTbl GetByID(int id)
        {
            return _akademikDanismanlarDAL.GetByID(id);
        }

        public List<AkademikDanismanlarTbl> GetListAll()
        {
            return _akademikDanismanlarDAL.GetListAll();
        }
    }
}
