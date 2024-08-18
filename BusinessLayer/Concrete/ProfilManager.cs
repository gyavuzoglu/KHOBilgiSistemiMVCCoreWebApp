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

        public ProfilTbl TGetByID(int id)
        {
            return _profilDAL.GetByID(id);
        }

        public List<ProfilTbl> GetListAll()
        {
            return _profilDAL.GetListAll();
        }

        public void ProfilAdd(ProfilTbl profilTbl)
        {
            _profilDAL.Insert(profilTbl);
        }

        public void ProfilDelete(ProfilTbl profilTbl)
        {
            _profilDAL.Delete(profilTbl);
        }

        public void ProfilUpdate(ProfilTbl profilTbl)
        {
            _profilDAL.Update(profilTbl);
        }
        public ProfilTbl GetByID(int id)
        {
            return _profilDAL.GetByID(id);
        }
    }
}
