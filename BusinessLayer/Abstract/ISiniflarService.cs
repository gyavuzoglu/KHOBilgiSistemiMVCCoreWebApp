using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISiniflarService
    {
        void SinifAdd(SiniflarTbl siniflarTbl);
        void SinifDelete(SiniflarTbl siniflarTbl);
        void SinifUpdate(SiniflarTbl siniflarTbl);
        List<SiniflarTbl> GetListAll();
        SiniflarTbl TGetByID(int id);
    }
}
