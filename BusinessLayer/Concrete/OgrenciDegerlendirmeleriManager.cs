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
    public class OgrenciDegerlendirmeleriManager:IOgrenciDegerlendirmeleriService
    {
        IOgrenciDegerlendirmeleriDAL _ogrenciDegerlendirmeleriDAL;

        public OgrenciDegerlendirmeleriManager(IOgrenciDegerlendirmeleriDAL ogrenciDegerlendirmeleriDAL)
        {
            _ogrenciDegerlendirmeleriDAL = ogrenciDegerlendirmeleriDAL;
        }

        public OgrenciDegerlendirmeleriTbl GetByID(int id)
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
        

        

    }
}
