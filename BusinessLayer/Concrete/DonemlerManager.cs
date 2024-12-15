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
    public class DonemlerManager:IDonemlerService
    {
        IDonemlerDAL _donemlerDAL;

        public DonemlerManager(IDonemlerDAL donemlerDAL)
        {
            _donemlerDAL = donemlerDAL;
        }

        public void DonemAdd(DonemlerTbl donemlerTbl)
        {
            _donemlerDAL.Insert(donemlerTbl);
        }

        public void DonemDelete(DonemlerTbl donemlerTbl)
        {
            _donemlerDAL.Delete(donemlerTbl);
        }

        public void DonemUpdate(DonemlerTbl donemlerTbl)
        {
            _donemlerDAL.Update(donemlerTbl);
        }

        
        public List<DonemlerTbl> GetListAll()
        {
            return _donemlerDAL.GetListAll();
        }

        public DonemlerTbl TGetByID(int id)
        {
            return _donemlerDAL.GetByID(id);
        }
    }
}
