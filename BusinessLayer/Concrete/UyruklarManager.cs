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
    public class UyruklarManager : IUyruklarService
    {
        IUyrukDAL _uyrukDAL;

        public UyruklarManager(IUyrukDAL uyrukDAL)
        {
            _uyrukDAL = uyrukDAL;
        }

        public UyrukTbl TGetByID(int id)
        {
            return _uyrukDAL.GetByID(id);
        }
        public UyrukTbl GetByID(int id)
        {
            return _uyrukDAL.GetByID(id);
        }
        public List<UyrukTbl> GetListAll()
        {
            return _uyrukDAL.GetListAll();
        }

        public void UyrukAdd(UyrukTbl uyrukTbl)
        {
            _uyrukDAL.Insert(uyrukTbl);
        }

        public void UyrukDelete(UyrukTbl uyrukTbl)
        {
            _uyrukDAL.Delete(uyrukTbl);
        }

        public void UyrukUpdate(UyrukTbl uyrukTbl)
        {
            _uyrukDAL.Update(uyrukTbl);
        }
    }
}
