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
    public class OgrenciDegerlendirmeTurleriManager:IOgrenciDegerlendirmeTurleriService
    {
        IOgrenciDegerlendirmeTurleriDAL _ogrenciDegerlendirmeTurleriDAL;

        public OgrenciDegerlendirmeTurleriManager(IOgrenciDegerlendirmeTurleriDAL ogrenciDegerlendirmeTurleriDAL)
        {
            _ogrenciDegerlendirmeTurleriDAL = ogrenciDegerlendirmeTurleriDAL;
        }

        public OgrenciDegerlendirmeTurleriTbl GetByID(int id)
        {
            return _ogrenciDegerlendirmeTurleriDAL.GetByID(id);
        }

        public List<OgrenciDegerlendirmeTurleriTbl> GetListAll()
        {
            return _ogrenciDegerlendirmeTurleriDAL.GetListAll();
        }

        public void OgrenciDegerlendirmeTuruAdd(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl)
        {
            _ogrenciDegerlendirmeTurleriDAL.Insert(ogrenciDegerlendirmeTurleriTbl);
        }

        public void OgrenciDegerlendirmeTuruDelete(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl)
        {
            _ogrenciDegerlendirmeTurleriDAL.Delete(ogrenciDegerlendirmeTurleriTbl);
        }

        public void OgrenciDegerlendirmeTuruUpdate(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl)
        {
            _ogrenciDegerlendirmeTurleriDAL.Update(ogrenciDegerlendirmeTurleriTbl);
        }
    }
}
