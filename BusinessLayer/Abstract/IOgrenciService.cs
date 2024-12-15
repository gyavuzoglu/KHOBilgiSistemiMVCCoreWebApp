using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOgrenciService
    {
        void OgrenciAdd(OgrencilerTbl ogrencilerTbl);
        void OgrenciDelete(OgrencilerTbl ogrencilerTbl);
        void OgrenciUpdate(OgrencilerTbl ogrencilerTbl);
        List<OgrencilerTbl> GetListAll();
        //List<OgrencilerTbl> OgrenciFilter(Expression<Func<OgrencilerTbl, bool>> filter);
        OgrencilerTbl GetByID(int id);
    }
}
