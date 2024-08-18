using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProfilService
    {
        void ProfilAdd(ProfilTbl profilTbl);
        void ProfilDelete(ProfilTbl profilTbl);
        void ProfilUpdate(ProfilTbl profilTbl);
        List<ProfilTbl> GetListAll();
        ProfilTbl GetByID(int id);
    }
}
