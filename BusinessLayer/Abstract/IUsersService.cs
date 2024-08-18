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
        void UserAdd(UsersTbl usersTbl );
        void UserDelete(UsersTbl usersTbl);
        void UserUpdate(UsersTbl usersTbl);
        List<UsersTbl> GetListAll();
        UsersTbl GetByID(int id);
    }
}
