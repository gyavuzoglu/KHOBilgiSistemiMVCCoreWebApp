using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        List<OgrenciDegerlendirmeleriTbl> GetList(int? EOYiliID, int? Donem, int? PerID);
        List<OgrenciDegerlendirmeleriTbl> DegerlendirmeFilter(Expression<Func<OgrenciDegerlendirmeleriTbl, bool>> filter);
        OgrenciDegerlendirmeleriTbl GetByID(long id);
        
    }
}
