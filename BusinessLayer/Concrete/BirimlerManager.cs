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
    public class BirimlerManager:IBirimlerService
    {
        IBirimlerDAL _birimlerDAL;

        public BirimlerManager(IBirimlerDAL birimlerDAL)
        {
            _birimlerDAL = birimlerDAL;
        }

        public void BirimAdd(BirimlerTbl birimlerTbl)
        {
            _birimlerDAL.Insert(birimlerTbl);
        }

        public void BirimDelete(BirimlerTbl birimlerTbl)
        {
            _birimlerDAL.Delete(birimlerTbl);
        }

        public void BirimUpdate(BirimlerTbl birimlerTbl)
        {
            _birimlerDAL.Update(birimlerTbl);
        }

        
        public List<BirimlerTbl> GetListAll()
        {
            return _birimlerDAL.GetListAll();
        }

        public BirimlerTbl TGetByID(int id)
        {
            return _birimlerDAL.GetByID(id);
        }
    }
}
