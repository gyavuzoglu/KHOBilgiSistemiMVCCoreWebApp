using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKisimDegerlendirmeleriService
    {
        void KisimDegerlendirmeAdd(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl);
        void KisimDegerlendirmeDelete(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl);
        void KisimDegerlendirmeUpdate(KisimDegerlendirmeleriTbl kisimDegerlendirmeleriTbl);
        List<KisimDegerlendirmeleriTbl> GetListAll();
        KisimDegerlendirmeleriTbl GetByID(int id);
    }
}
