using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserRolesService
    {
        void UserRolesAdd(UserRolesTbl userRolesTbl);
        void UserRolesDelete(UserRolesTbl userRolesTbl);
        void UserRolesUpdate(UserRolesTbl userRolesTbl);
        List<UserRolesTbl> GetListAll();
        UserRolesTbl TGetByID(int id);
    }
}
