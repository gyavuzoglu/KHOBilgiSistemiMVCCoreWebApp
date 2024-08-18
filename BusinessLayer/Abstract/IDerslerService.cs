using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDerslerService
    {
        void DersAdd(DerslerTbl derslerTbl);
        void DersDelete(DerslerTbl derslerTbl);
        void DersUpdate(DerslerTbl derslerTbl);
        List<DerslerTbl> GetListAll();
        DerslerTbl GetByID(int id);
    }
}
