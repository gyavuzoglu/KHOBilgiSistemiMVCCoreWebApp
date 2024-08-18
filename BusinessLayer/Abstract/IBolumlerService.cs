using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBolumlerService
    {
        void BolumAdd(BolumTbl bolumTbl);
        void BolumDelete(BolumTbl bolumTbl);
        void BolumUpdate(BolumTbl bolumTbl);
        List<BolumTbl> GetListAll();
        BolumTbl GetByID(int id);
    }
}
