using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUyruklarService
    {
        void UyrukAdd(UyrukTbl uyrukTbl);
        void UyrukDelete(UyrukTbl uyrukTbl);
        void UyrukUpdate(UyrukTbl uyrukTbl);
        List<UyrukTbl> GetListAll();
        UyrukTbl GetByID(int id);
    }
}
