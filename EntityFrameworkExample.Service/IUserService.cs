using EntityFrameworkExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Service
{
    public interface IUserService
    {
        Users GetByID(int id);
        List<Users> GetList();
        void UserAdd(Users user);
        void UserDelete(Users user);
        void UserUpdate(Users user);
    }
}