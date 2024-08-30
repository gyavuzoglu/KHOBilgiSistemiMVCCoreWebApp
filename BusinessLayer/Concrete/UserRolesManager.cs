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
    public class UserRolesManager : IUserRolesService
    {
        IUserRolesDAL _userRolesDAL;

        public UserRolesManager(IUserRolesDAL userRolesDAL)
        {
            _userRolesDAL = userRolesDAL;
        }
        public List<UserRolesTbl> GetListAll()
        {
            return _userRolesDAL.GetListAll();
        }

        public UserRolesTbl TGetByID(int id)
        {
            return _userRolesDAL.GetByID(id);
        }

        public void UserRolesAdd(UserRolesTbl userRolesTbl)
        {
            _userRolesDAL.Insert(userRolesTbl);
        }

        public void UserRolesDelete(UserRolesTbl userRolesTbl)
        {
            _userRolesDAL.Delete(userRolesTbl);
        }

        public void UserRolesUpdate(UserRolesTbl userRolesTbl)
        {
            _userRolesDAL.Update(userRolesTbl);
        }
    }
}
