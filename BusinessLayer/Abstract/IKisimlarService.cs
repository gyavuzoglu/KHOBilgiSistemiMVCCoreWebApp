using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKisimlarService
    {
        void KisimAdd(KisimlarTbl kisimlarTbl);
        void KisimDelete(KisimlarTbl kisimlarTbl);
        void KisimUpdate(KisimlarTbl kisimlarTbl);
        List<KisimlarTbl> GetListAll();
        KisimlarTbl GetByID(int id);
    }
}
