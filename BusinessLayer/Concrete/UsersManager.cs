using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDAL _usersDAL;

        public UsersManager(IUsersDAL usersDAL)
        {
            _usersDAL = usersDAL;
        }

        public UsersTbl TGetByID(int id)
        {
            return _usersDAL.GetByID(id);
        }
        public UsersTbl GetByID(int id)
        {
            return _usersDAL.GetByID(id);
        }
        public List<UsersTbl> GetListAll()
        {
            return _usersDAL.GetListAll();
        }

        public void UserAdd(UsersTbl usersTbl)
        {
            _usersDAL.Insert(usersTbl);
        }

        public void UserDelete(UsersTbl usersTbl)
        {
            _usersDAL.Delete(usersTbl);
        }

        public void UserUpdate(UsersTbl usersTbl)
        {
            _usersDAL.Update(usersTbl);
        }
    }
}
