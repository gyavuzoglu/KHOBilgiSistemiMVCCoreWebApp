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
    public class KisimlarManager : IKisimlarService
    {
        IKisimlarDAL _kisimlarDAL;

        public KisimlarManager(IKisimlarDAL kisimlarDAL)
        {
            _kisimlarDAL = kisimlarDAL;
        }

        public KisimlarTbl TGetByID(int id)
        {
            return _kisimlarDAL.GetByID(id);
        }

        public List<KisimlarTbl> GetListAll()
        {
            return _kisimlarDAL.GetListAll();
        }

        public void KisimAdd(KisimlarTbl kisimlarTbl)
        {
            _kisimlarDAL.Insert(kisimlarTbl);
        }

        public void KisimDelete(KisimlarTbl kisimlarTbl)
        {
            _kisimlarDAL.Delete(kisimlarTbl);
        }

        public void KisimUpdate(KisimlarTbl kisimlarTbl)
        {
            _kisimlarDAL.Update(kisimlarTbl);
        }

        public KisimlarTbl GetByID(int id)
        {
            return _kisimlarDAL.GetByID(id);
        }
    }
}
