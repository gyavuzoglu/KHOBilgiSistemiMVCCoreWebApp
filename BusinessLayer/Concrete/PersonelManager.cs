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
    public class PersonelManager : IPersonelService
    {
        IPersonelDAL _personelDAL;

        public PersonelManager(IPersonelDAL personelDAL)
        {
            _personelDAL = personelDAL;
        }

        public PersonelTbl TGetByID(int id)
        {
            return _personelDAL.GetByID(id);
        }

        public List<PersonelTbl> GetListAll()
        {
            return _personelDAL.GetListAll();
        }

        public void PersonelAdd(PersonelTbl personelTbl)
        {
            _personelDAL.Insert(personelTbl);
        }

        public void PersonelDelete(PersonelTbl personelTbl)
        {
            _personelDAL.Delete(personelTbl);
        }

        public void PersonelUpdate(PersonelTbl personelTbl)
        {
            _personelDAL.Update(personelTbl);
        }

        public PersonelTbl GetByID(int id)
        {
            return _personelDAL.GetByID(id);
        }
    }
}
