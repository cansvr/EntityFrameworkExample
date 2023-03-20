using EntityFrameworkExample.Data.Entities;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Service
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Users GetByID(int id)
        {
            return _userDal.Get(x => x.USER_CODE == id);
        }

        public List<Users> GetList()
        {
            return _userDal.List();
        }

        public void UserAdd(Users user)
        {
            _userDal.Insert(user);
        }

        public void UserDelete(Users user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdate(Users user)
        {
            _userDal.Update(user);
        }
    }
}
