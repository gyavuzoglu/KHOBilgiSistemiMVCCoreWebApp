using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonelService
    {
        void PersonelAdd(PersonelTbl personelTbl);
        void PersonelDelete(PersonelTbl personelTbl);
        void PersonelUpdate(PersonelTbl personelTbl );
        List<PersonelTbl> GetListAll();
        PersonelTbl GetByID(int id);
    }
}
