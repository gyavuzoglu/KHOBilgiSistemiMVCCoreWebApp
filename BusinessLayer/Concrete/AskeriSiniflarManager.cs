using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AskeriSiniflarManager : IAskeriSiniflarService
    {
        IAskeriSiniflarDAL _askeriSiniflarDAL;
        
        public AskeriSiniflarManager(IAskeriSiniflarDAL askeriSiniflarDAL)
        {
            _askeriSiniflarDAL = askeriSiniflarDAL;
        }

        public void AskeriSinifAdd(AskeriSiniflarTbl askeriSiniflarTbl)
        {
            _askeriSiniflarDAL.Insert(askeriSiniflarTbl);
        }

        public void AskeriSinifDelete(AskeriSiniflarTbl askeriSiniflarTbl)
        {
            _askeriSiniflarDAL.Delete(askeriSiniflarTbl);
        }

        public void AskeriSinifUpdate(AskeriSiniflarTbl askeriSiniflarTbl)
        {
            _askeriSiniflarDAL.Update(askeriSiniflarTbl);
        }

        public AskeriSiniflarTbl TGetByID(int id)
        {
            return _askeriSiniflarDAL.GetByID(id);
        }

        public List<AskeriSiniflarTbl> GetListAll()
        {
            return _askeriSiniflarDAL.GetListAll();
        }

        public AskeriSiniflarTbl GetByID(int id)
        {
            return _askeriSiniflarDAL.GetByID((int)id);
        }
    }
}
