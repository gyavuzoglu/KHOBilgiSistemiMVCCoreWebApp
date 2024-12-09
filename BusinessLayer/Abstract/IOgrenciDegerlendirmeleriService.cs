using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOgrenciDegerlendirmeleriService
    {
        void OgrenciDegerlendirmeAdd(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl);
        void OgrenciDegerlendirmeDelete(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl);
        void OgrenciDegerlendirmeUpdate(OgrenciDegerlendirmeleriTbl ogrenciDegerlendirmeleriTbl);
        List<OgrenciDegerlendirmeleriTbl> GetListAll();
        OgrenciDegerlendirmeleriTbl GetByID(int id);
        
    }
}
