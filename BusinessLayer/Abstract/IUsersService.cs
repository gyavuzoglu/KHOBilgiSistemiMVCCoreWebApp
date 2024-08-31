using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUsersService
    {
        void UserAdd(UserTbl usersTbl );
        void UserDelete(UserTbl usersTbl);
        void UserUpdate(UserTbl usersTbl);
        List<UserTbl> GetListAll();
        UserTbl TGetByID(int id);
    }
}
