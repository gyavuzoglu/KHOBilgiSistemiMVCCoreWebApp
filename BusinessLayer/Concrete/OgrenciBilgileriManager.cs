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
    public class OgrenciBilgileriManager : IOgrenciBilgileriService
    {
        IOgrenciBilgileriDAL _ogrenciBilgileriDAL;

        public OgrenciBilgileriManager(IOgrenciBilgileriDAL ogrenciBilgileriDAL)
        {
            _ogrenciBilgileriDAL = ogrenciBilgileriDAL;
        }

        public OgrenciBilgileriTbl TGetByID(int id)
        {
            return _ogrenciBilgileriDAL.GetByID(id);
        }

        public List<OgrenciBilgileriTbl> GetListAll()
        {
            return _ogrenciBilgileriDAL.GetListAll();
        }

        public void OgrenciBilgiAdd(OgrenciBilgileriTbl ogrenciBilgileriTbl)
        {
            _ogrenciBilgileriDAL.Insert(ogrenciBilgileriTbl);
        }

        public void OgrenciBilgiDelete(OgrenciBilgileriTbl ogrenciBilgileriTbl)
        {
            _ogrenciBilgileriDAL.Delete(ogrenciBilgileriTbl);
        }

        public void OgrenciBilgiUpdate(OgrenciBilgileriTbl ogrenciBilgileriTbl)
        {
            _ogrenciBilgileriDAL.Update(ogrenciBilgileriTbl);
        }

        public OgrenciBilgileriTbl GetByID(int id)
        {
            return _ogrenciBilgileriDAL.GetByID(id);
        }
    }
}
