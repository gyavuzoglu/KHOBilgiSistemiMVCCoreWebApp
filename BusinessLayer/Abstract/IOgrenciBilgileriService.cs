using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOgrenciBilgileriService
    {
        void OgrenciBilgiAdd(OgrenciBilgileriTbl ogrenciBilgileriTbl);
        void OgrenciBilgiDelete(OgrenciBilgileriTbl ogrenciBilgileriTbl);
        void OgrenciBilgiUpdate(OgrenciBilgileriTbl ogrenciBilgileriTbl);
        List<OgrenciBilgileriTbl> GetListAll();
        OgrenciBilgileriTbl GetByID(int id);
    }
}
