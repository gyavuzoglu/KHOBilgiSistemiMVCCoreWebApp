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
    public class DerslerManager : IDerslerService
    {
        IDerslerDAL _derslerDAL;

        public DerslerManager(IDerslerDAL derslerDAL)
        {
            _derslerDAL = derslerDAL;
        }

        public void DersAdd(DerslerTbl derslerTbl)
        {
            _derslerDAL.Insert(derslerTbl);
        }

        public void DersDelete(DerslerTbl derslerTbl)
        {
            _derslerDAL.Delete(derslerTbl);
        }

        public void DersUpdate(DerslerTbl derslerTbl)
        {
            _derslerDAL.Update(derslerTbl);
        }

        public DerslerTbl TGetByID(int id)
        {
            return _derslerDAL.GetByID(id);
        }

        public List<DerslerTbl> GetListAll()
        {
            return _derslerDAL.GetListAll();
        }

        public DerslerTbl GetByID(int id)
        {
            return _derslerDAL.GetByID(id);
        }
    }
}
