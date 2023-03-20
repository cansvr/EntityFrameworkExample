using EntityFrameworkExample.Api.Controllers;
using EntityFrameworkExample.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace EntityFrameworkExampleçUnitTest
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
            user = new Users() { USER_NAME = "test" };
            result = new UserController().AddUser(user);
            Assert.AreEqual(user.USER_NAME + " Kullanıcısı için Ekleme Başarılı!", result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            string result = "";
            Users user = new Users();
            user = new Users() { USER_CODE = 1, USER_NAME = "Can" };
            result = new UserController().UpdateUser(user);
            Assert.AreEqual(user.USER_NAME + " Kullanıcısı için Güncelleme Başarılı!", result);
        }
    }
}
