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
    public class BolumlerManager : IBolumlerService
    {
        IBolumDAL _bolumDAL;

        public BolumlerManager(IBolumDAL bolumDAL)
        {
            _bolumDAL = bolumDAL;
        }

        public void BolumAdd(BolumTbl bolumTbl)
        {
            _bolumDAL.Insert(bolumTbl);
        }

        public void BolumDelete(BolumTbl bolumTbl)
        {
            _bolumDAL.Delete(bolumTbl);
        }

        public void BolumUpdate(BolumTbl bolumTbl)
        {
            _bolumDAL.Update(bolumTbl);
            
        }

        public BolumTbl TGetByID(int id)
        {
            return _bolumDAL.GetByID(id);
        }

        public List<BolumTbl> GetListAll()
        {
            return _bolumDAL.GetListAll();
        }

        public BolumTbl GetByID(int id)
        {
            return _bolumDAL.GetByID(id);
        }
    }
}
