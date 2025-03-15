using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OgrenciDegerlendirmeleriManager:IOgrenciDegerlendirmeleriService
    {
        IOgrenciDegerlendirmeleriDAL _ogrenciDegerlendirmeleriDAL;

        public OgrenciDegerlendirmeleriManager(IOgrenciDegerlendirmeleriDAL ogrenciDegerlendirmeleriDAL)
        {
            _ogrenciDegerlendirmeleriDAL = ogrenciDegerlendirmeleriDAL;
        }

        public OgrenciDegerlendirmeleriTbl GetByID(long id)
        {
            return _ogrenciDegerlendirmeleriDAL.GetByID(id);
        }

        public List<OgrenciDegerlendirmeleriTbl> GetListAll()
        {
            return _ogrenciDegerlendirmeleriDAL.GetListAll();
        }

        public void OgrenciDegerlendirmeAdd(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl)
        {
            _ogrenciDegerlendirmeleriDAL.Insert(ogrenciDegerlendirmeleriTbl);
        }

        public void OgrenciDegerlendirmeDelete(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl)
        {
            _ogrenciDegerlendirmeleriDAL.Delete(ogrenciDegerlendirmeleriTbl);
        }

        public void OgrenciDegerlendirmeUpdate(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl)
        {
            _ogrenciDegerlendirmeleriDAL.Update(ogrenciDegerlendirmeleriTbl);
        }
        
        public List<OgrenciDegerlendirmeleriTbl> GetList(int? EOYiliID, int? Donem, long? PerID)
        {
            return _ogrenciDegerlendirmeleriDAL.GetList(x=>x.EOYiliID==EOYiliID && x.Donem==Donem && x.PerID==PerID);
        }

        public List<OgrenciDegerlendirmeleriTbl> DegerlendirmeFilter(Expression<Func<OgrenciDegerlendirmeleriTbl, bool>> filter)
        {
            using var c = new Context();
            return c.Set<OgrenciDegerlendirmeleriTbl>().Where(filter).ToList();
        }

        


    }
}
