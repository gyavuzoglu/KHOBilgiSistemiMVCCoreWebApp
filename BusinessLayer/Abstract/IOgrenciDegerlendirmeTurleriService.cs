using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOgrenciDegerlendirmeTurleriService
    {
        void OgrenciDegerlendirmeTuruAdd(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl);
        void OgrenciDegerlendirmeTuruDelete(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl);
        void OgrenciDegerlendirmeTuruUpdate(OgrenciDegerlendirmeTurleriTbl ogrenciDegerlendirmeTurleriTbl);
        List<OgrenciDegerlendirmeTurleriTbl> GetListAll();
        OgrenciDegerlendirmeTurleriTbl GetByID(int id);
    }
}
