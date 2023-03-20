using EntityLayer.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace EntityFrameworkExample.UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void GetUser()
        {
            IList<Users> userList = new List<Users>();
            userList = new UserController().GetUserList();
            Assert.IsNotNull(userList);
        }

        [TestMethod]
        public void AddUser()
        {
            var result = "";
            Users user = new Users();
            user = new Users() { USER_NAME = "test", USER_SURNAME = "test2", USER_MAIL = "can.sever@bilgiyon.com.tr", ROLE_CODE = 1 };
            result = new UserController().AddUser(user);
            Assert.AreEqual(user.USER_NAME + " Kullanıcısı için Ekleme Başarılı!", result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            string result = "";
            Users user = new Users();
            user = new Users() { USER_CODE = 1, USER_NAME = "Can", USER_SURNAME = "Sever", USER_MAIL = "can.sever@bilgiyon.com.tr", ROLE_CODE = 1 };
            result = new UserController().UpdateUser(user);
            Assert.AreEqual(user.USER_NAME + " Kullanıcısı için Güncelleme Başarılı!", result);
        }
    }
}
