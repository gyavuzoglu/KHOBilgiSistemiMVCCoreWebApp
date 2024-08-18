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
    public class UnvanlarManager : IUnvanlarService
    {
        IUnvanDAL _unvanDAL;

        public UnvanlarManager(IUnvanDAL unvanDAL)
        {
            _unvanDAL = unvanDAL;
        }

        public UnvanTbl TGetByID(int id)
        {
            return _unvanDAL.GetByID(id);
        }
        public UnvanTbl GetByID(int id)
        {
            return _unvanDAL.GetByID(id);
        }
        public List<UnvanTbl> GetListAll()
        {
            return _unvanDAL.GetListAll();
        }

        public void UnvanAdd(UnvanTbl unvanTbl)
        {
            _unvanDAL.Insert(unvanTbl);
        }

        public void UnvanDelete(UnvanTbl unvanTbl)
        {
            _unvanDAL.Delete(unvanTbl);
        }

        public void UnvanUpdate(UnvanTbl unvanTbl)
        {
            _unvanDAL.Update(unvanTbl);
        }
    }
}
