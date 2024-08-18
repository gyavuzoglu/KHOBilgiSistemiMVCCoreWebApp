using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GorevlerManager : IGorevlerService
    {
        IGorevlerDAL _gorevlerDAL;

        public GorevlerManager(IGorevlerDAL gorevlerDAL)
        {
            _gorevlerDAL = gorevlerDAL;
        }

        public GorevlerTbl TGetByID(int id)
        {
            return _gorevlerDAL.GetByID(id);
        }

        public List<GorevlerTbl> GetListAll()
        {
            return _gorevlerDAL.GetListAll();
        }

        public void GorevAdd(GorevlerTbl gorevlerTbl)
        {
            _gorevlerDAL.Insert(gorevlerTbl);
        }

        public void GorevDelete(GorevlerTbl gorevlerTbl)
        {
            _gorevlerDAL.Delete(gorevlerTbl);
        }

        public void GorevUpdate(GorevlerTbl gorevlerTbl)
        {
            _gorevlerDAL.Update(gorevlerTbl);
        }

        public GorevlerTbl GetByID(int id)
        {
            return _gorevlerDAL.GetByID(id);
        }
    }
}
