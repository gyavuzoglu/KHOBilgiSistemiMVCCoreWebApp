using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EOYiliManager : IEOYiliService
    {
        IEOYiliDAL _eOYiliDAL;

        public EOYiliManager(IEOYiliDAL eOYiliDAL)
        {
            _eOYiliDAL = eOYiliDAL;
        }

        public void EOYiliAdd(EOYiliTbl eOYiliTbl)
        {
            _eOYiliDAL.Insert(eOYiliTbl);
        }

        public void EOYiliDelete(EOYiliTbl eOYiliTbl)
        {
            _eOYiliDAL.Delete(eOYiliTbl);
        }

        public void EOYiliUpdate(EOYiliTbl eOYiliTbl)
        {
            _eOYiliDAL.Update(eOYiliTbl);
        }

        public EOYiliTbl TGetByID(int id)
        {
            return _eOYiliDAL.GetByID(id);
        }

        public List<EOYiliTbl> GetListAll()
        {
            return _eOYiliDAL.GetListAll();
        }

        public EOYiliTbl GetByID(int id)
        {
            return _eOYiliDAL.GetByID(id);
        }
    }
}
