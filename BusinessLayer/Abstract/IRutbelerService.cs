using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRutbelerService
    {
        void RutbeAdd(RutbeTbl rutbeTbl);
        void RutbeDelete(RutbeTbl rutbeTbl);
        void RutbeUpdate(RutbeTbl rutbeTbl);
        List<RutbeTbl> GetListAll();
        RutbeTbl GetByID(int id);
    }
}
