using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUnvanlarService
    {
        void UnvanAdd(UnvanTbl unvanTbl);
        void UnvanDelete(UnvanTbl unvanTbl);
        void UnvanUpdate(UnvanTbl unvanTbl);
        List<UnvanTbl> GetListAll();
        UnvanTbl GetByID(int id);
    }
}
