using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KisimDegerlendirmeleriManager:IKisimDegerlendirmeleriService
    {
        IKisimDegerlendirmeleriDAL _kisimDegerlendirmeleriDAL;

        public KisimDegerlendirmeleriManager(IKisimDegerlendirmeleriDAL kisimDegerlendirmeleriDAL)
        {
            _kisimDegerlendirmeleriDAL = kisimDegerlendirmeleriDAL;
        }

        public KisimDegerlendirmeleriTbl GetByID(long id)
        {
            return _kisimDegerlendirmeleriDAL.GetByID(id);
        }

        public List<KisimDegerlendirmeleriTbl> GetListAll()
        {
            return _kisimDegerlendirmeleriDAL.GetListAll();
        }

        public void KisimDegerlendirmeAdd(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl)
        {
            _kisimDegerlendirmeleriDAL.Insert(kisimDegerlendirmeleriTbl);
        }

        public void KisimDegerlendirmeDelete(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl)
        {
            _kisimDegerlendirmeleriDAL.Delete(kisimDegerlendirmeleriTbl);
        }

        public void KisimDegerlendirmeUpdate(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl)
        {
            _kisimDegerlendirmeleriDAL.Update(kisimDegerlendirmeleriTbl);
        }

        public List<KisimDegerlendirmeleriTbl> GetList(int? EOYiliID, int? Donem, int? PerID)
        {
            return _kisimDegerlendirmeleriDAL.GetList(x => x.EOYiliID == EOYiliID && x.Donem == Donem && x.PerID == PerID);
        }
    }
}
