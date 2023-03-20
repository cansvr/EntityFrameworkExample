using EntityFrameworkExample.Data.Entities;
using EntityFrameworkExample.Repository;
using EntityFrameworkExample.Service;
using FluentValidation.Results;
using System.Web.Mvc;

namespace EntityFrameworkExample.WebApp.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();

        public ActionResult Index()
        {
            var userValues = um.GetList();
            return View(userValues);
        }

        public ActionResult GetUserList()
        {
            var userList = um.GetList();
            return View(userList);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Users p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserAdd(p);
                return RedirectToAction("GetUserList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var writerValue = um.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditUser(Users p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}