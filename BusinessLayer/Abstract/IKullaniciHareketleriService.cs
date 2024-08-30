using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKullaniciHareketleriService
    {
        void KullaniciHareketleriAdd(KullaniciHareketleriTbl kullaniciHareketleriTbl);
        void KullaniciHareketleriDelete(KullaniciHareketleriTbl kullaniciHareketleriTbl);
        void KullaniciHareketleriUpdate(KullaniciHareketleriTbl kullaniciHareketleriTbl);
        List<KullaniciHareketleriTbl> GetListAll();
        KullaniciHareketleriTbl TGetByID(int id);
    }
}
