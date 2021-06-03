using ShopStore.Dal.ShopStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopStore.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Show()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoginIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIn(ShopStore.Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (isValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    ModelState.AddModelError("", "Login wrong");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Registration(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ShopStoreContext())
                {

                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(user.Password);
                    var sysUser = db.User.Create();

                    sysUser.Email = user.Email;
                    sysUser.Password = encrypPass;
                    sysUser.PasswordSalt = crypto.Salt;

                    db.User.Add(sysUser);
                    db.SaveChanges();

                    return RedirectToAction("List", "Product");

                }

            }

            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "Product");
        }

        private bool isValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            using (var db = new ShopStoreContext())
            {
                var user = db.User.FirstOrDefault(u => u.Email == email);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

    }
}
