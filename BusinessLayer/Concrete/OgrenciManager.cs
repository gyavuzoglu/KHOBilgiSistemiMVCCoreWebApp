using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        IOgrencilerDAL _ogrencilerDAL;

        public OgrenciManager(IOgrencilerDAL ogrencilerDAL)
        {
            _ogrencilerDAL = ogrencilerDAL;
        }

        public OgrencilerTbl TGetByID(int id)
        {
            return _ogrencilerDAL.GetByID(id);
        }

        public List<OgrencilerTbl> GetListAll()
        {
            return _ogrencilerDAL.GetListAll();
        }

        public void OgrenciAdd(OgrencilerTbl ogrencilerTbl)
        {
            _ogrencilerDAL.Insert(ogrencilerTbl);
        }

        public void OgrenciDelete(OgrencilerTbl ogrencilerTbl)
        {
            _ogrencilerDAL.Delete(ogrencilerTbl);
        }

        public void OgrenciUpdate(OgrencilerTbl ogrencilerTbl)
        {
            _ogrencilerDAL.Update(ogrencilerTbl);
        }

        public OgrencilerTbl GetByID(int id)
        {
            return _ogrencilerDAL.GetByID(id);
        }

        //public List<OgrencilerTbl> OgrenciFilter(Expression<Func<OgrencilerTbl, bool>> filter)
        //{
        //    using var c = new Context();
        //    return c.Set<OgrencilerTbl>().Where(filter).ToList();
        //}
    }
}
