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

        public UserTbl TGetByID(int id)
        {
            return _usersDAL.GetByID(id);
        }
        public UserTbl GetByID(int id)
        {
            return _usersDAL.GetByID(id);
        }
        public List<UserTbl> GetListAll()
        {
            return _usersDAL.GetListAll();
        }

        public void UserAdd(UserTbl usersTbl)
        {
            _usersDAL.Insert(usersTbl);
        }

        public void UserDelete(UserTbl usersTbl)
        {
            _usersDAL.Delete(usersTbl);
        }

        public void UserUpdate(UserTbl usersTbl)
        {
            _usersDAL.Update(usersTbl);
        }
    }
}
