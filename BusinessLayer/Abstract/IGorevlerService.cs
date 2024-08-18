using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGorevlerService
    {
        void GorevAdd(GorevlerTbl gorevlerTbl);
        void GorevDelete(GorevlerTbl gorevlerTbl);
        void GorevUpdate(GorevlerTbl gorevlerTbl);
        List<GorevlerTbl> GetListAll();
        GorevlerTbl GetByID(int id);
    }
}
