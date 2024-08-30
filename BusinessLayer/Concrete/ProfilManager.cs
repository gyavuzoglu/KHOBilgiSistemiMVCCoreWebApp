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
    public class ProfilManager : IProfilService
    {
        IProfilDAL _profilDAL;

        public ProfilManager(IProfilDAL profilDAL)
        {
            _profilDAL = profilDAL;
        }

        public RolesTbl TGetByID(int id)
        {
            return _profilDAL.GetByID(id);
        }

        public List<RolesTbl> GetListAll()
        {
            return _profilDAL.GetListAll();
        }

        public void ProfilAdd(RolesTbl profilTbl)
        {
            _profilDAL.Insert(profilTbl);
        }

        public void ProfilDelete(RolesTbl profilTbl)
        {
            _profilDAL.Delete(profilTbl);
        }

        public void ProfilUpdate(RolesTbl profilTbl)
        {
            _profilDAL.Update(profilTbl);
        }
        public RolesTbl GetByID(int id)
        {
            return _profilDAL.GetByID(id);
        }
    }
}
