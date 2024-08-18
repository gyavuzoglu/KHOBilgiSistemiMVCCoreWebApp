using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        OgrencilerTbl GetByID(int id);
    }
}
