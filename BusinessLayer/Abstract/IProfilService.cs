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
        void ProfilAdd(RolesTbl profilTbl);
        void ProfilDelete(RolesTbl profilTbl);
        void ProfilUpdate(RolesTbl profilTbl);
        List<RolesTbl> GetListAll();
        RolesTbl GetByID(int id);
    }
}
