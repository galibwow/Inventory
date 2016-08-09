using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(string user, string pass)
        {
            var context = new InventoryDBContext();
            var login = context.users.FirstOrDefault(a => a.username == user && a.password == pass);
            if (login == null)
            {
                return View();
            }
            else if (login.user_type == 1)
            {
                GetSession(login);
                return RedirectToAction("Index", "User", new { id = login.id });
            }
            else if (login.user_type == 2)
            {
                return RedirectToAction("Index");
            }
            else if (login.user_type == 3)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        private void GetSession(user user)
        {
            Session["User"] = user.id;
        }


    }
}
