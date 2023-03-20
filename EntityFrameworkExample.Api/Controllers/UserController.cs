using EntityFrameworkExample.Data.Entities;
using EntityFrameworkExample.Repository;
using EntityFrameworkExample.Service;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EntityFrameworkExample.Api.Controllers
{
    public class UserController : ApiController
    {
        UserManager um = new UserManager(new EfUserDal());

        [HttpGet]
        [Route("User/GetUserList")]
        public IList<Users> GetUserList()
        {
            IList<Users> userList = new List<Users>();
            try
            {
                userList = um.GetList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return userList;
        }

        [HttpPost]
        [Route("User/AddUser")]
        public string AddUser(Users p)
        {
            try
            {
                UserValidator userValidator = new UserValidator();
                ValidationResult results = userValidator.Validate(p);

                if (results.IsValid)
                {
                    um.UserAdd(p);
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return p.USER_NAME + " Kullanıcısı için Ekleme Başarısız! Hata Mesajları: " + results.ToString().Replace("\r\n", " - ");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return p.USER_NAME + " Kullanıcısı için Ekleme Başarılı!";
        }

        [HttpPost]
        [Route("User/UpdateUser")]
        public string UpdateUser(Users p)
        {
            try
            {
                UserValidator userValidator = new UserValidator();
                ValidationResult results = userValidator.Validate(p);
                Users user = new Users();
                if (results.IsValid)
                {
                    if (p.USER_CODE == 0)
                    {
                        return "Kullanıcı Kodu Girilmelidir!";
                    }

                    user = um.GetByID(p.USER_CODE);
                    if (user == null)
                    {
                        return p.USER_NAME + " Kullanıcısı Bulunamadı!";
                    }

                    user.USER_NAME = p.USER_NAME;

                    um.UserUpdate(user);
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return p.USER_NAME + " Kullanıcısı için Güncelleme Başarısız! Hata Mesajları: " + results.ToString().Replace("\r\n", " - ");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return p.USER_NAME + " Kullanıcısı için Güncelleme Başarılı!";
        }
    }
}
