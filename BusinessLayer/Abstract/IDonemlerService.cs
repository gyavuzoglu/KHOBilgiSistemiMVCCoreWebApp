using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDonemlerService
    {
        void DonemAdd(DonemlerTbl donemlerTbl);
        void DonemDelete(DonemlerTbl donemlerTbl);
        void DonemUpdate(DonemlerTbl donemlerTbl);
        List<DonemlerTbl> GetListAll();
        DonemlerTbl TGetByID(int id);
    }
}
