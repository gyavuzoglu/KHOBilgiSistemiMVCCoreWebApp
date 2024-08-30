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
    public class KullaniciHareketleriManager : IKullaniciHareketleriService
    {
        IKullaniciHareketleriDAL _kullaniciHareketleriDAL;

        public KullaniciHareketleriManager(IKullaniciHareketleriDAL kullaniciHareketleriDAL)
        {
            _kullaniciHareketleriDAL = kullaniciHareketleriDAL;
        }
        public List<KullaniciHareketleriTbl> GetListAll()
        {
            return _kullaniciHareketleriDAL.GetListAll();
        }

        public void KullaniciHareketleriAdd(KullaniciHareketleriTbl kullaniciHareketleriTbl)
        {
            _kullaniciHareketleriDAL.Insert(kullaniciHareketleriTbl);
        }

        public void KullaniciHareketleriDelete(KullaniciHareketleriTbl kullaniciHareketleriTbl)
        {
            _kullaniciHareketleriDAL.Delete(kullaniciHareketleriTbl);
        }

        public void KullaniciHareketleriUpdate(KullaniciHareketleriTbl kullaniciHareketleriTbl)
        {
            _kullaniciHareketleriDAL.Update(kullaniciHareketleriTbl);
        }

        public KullaniciHareketleriTbl TGetByID(int id)
        {
            return _kullaniciHareketleriDAL.GetByID(id);
        }
    }
}
