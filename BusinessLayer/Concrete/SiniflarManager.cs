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
    public class SiniflarManager:ISiniflarService
    {
        ISiniflarDAL _siniflarDAL;

        public SiniflarManager(ISiniflarDAL siniflarDAL)
        {
            _siniflarDAL = siniflarDAL;
        }

        public void SinifAdd(SiniflarTbl siniflarTbl)
        {
            _siniflarDAL.Insert(siniflarTbl);
        }

        public void SinifDelete(SiniflarTbl siniflarTbl)
        {
            _siniflarDAL.Delete(siniflarTbl);
        }

        public void SinifUpdate(SiniflarTbl siniflarTbl)
        {
            _siniflarDAL.Update(siniflarTbl);
        }

        
        public List<SiniflarTbl> GetListAll()
        {
            return _siniflarDAL.GetListAll();
        }

        public SiniflarTbl TGetByID(int id)
        {
            return _siniflarDAL.GetByID(id);
        }
    }
}
