using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RutbelerManager : IRutbelerService
    {
        IRutbeDAL _rutbeDAL;

        public RutbelerManager(IRutbeDAL rutbeDAL)
        {
            _rutbeDAL = rutbeDAL;
        }

        public RutbeTbl TGetByID(int id)
        {
            return _rutbeDAL.GetByID(id);
        }
        public RutbeTbl GetByID(int id)
        {
            return _rutbeDAL.GetByID(id);
        }
        public List<RutbeTbl> GetListAll()
        {
            return _rutbeDAL.GetListAll();
        }

        public void RutbeAdd(RutbeTbl rutbeTbl)
        {
            _rutbeDAL.Insert(rutbeTbl);
        }

        public void RutbeDelete(RutbeTbl rutbeTbl)
        {
            _rutbeDAL.Delete(rutbeTbl);
        }

        public void RutbeUpdate(RutbeTbl rutbeTbl)
        {
            _rutbeDAL.Update(rutbeTbl);
        }
    }
}
