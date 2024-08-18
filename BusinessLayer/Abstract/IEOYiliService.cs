using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEOYiliService
    {
        void EOYiliAdd(EOYiliTbl eOYiliTbl);
        void EOYiliDelete(EOYiliTbl eOYiliTbl);
        void EOYiliUpdate(EOYiliTbl eOYiliTbl);
        List<EOYiliTbl> GetListAll();
        EOYiliTbl GetByID(int id);
    }
}
