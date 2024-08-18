using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBirimlerService
    {
        void BirimAdd(BirimlerTbl birimlerTbl);
        void BirimDelete(BirimlerTbl birimlerTbl);
        void BirimUpdate(BirimlerTbl birimlerTbl);
        List<BirimlerTbl> GetListAll();
        BirimlerTbl TGetByID(int id);
    }
}
