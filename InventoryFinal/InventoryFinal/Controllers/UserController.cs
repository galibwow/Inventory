using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private InventoryDBContext context = new InventoryDBContext();

        public ActionResult Index()
        {
            ViewBag.Name = GetSession();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [ActionName("Create")]
        public ActionResult Create_p(user U)
        {
       
         
            try
            {

                context.users.Add(U);
                context.SaveChanges();
                ModelState.Clear();
                U = null;
                ViewBag.Message = "Successfully Registration Done";
      
                return RedirectToAction("Index", "User");
            }
            catch (Exception)
            {

                return View();
            }
        }
        //[HttpGet]
        //public ActionResult login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ActionName("login")]
        //public ActionResult login_l( user us)
        //{
        //   var op =context.users.SingleOrDefault(a => a.username == us.username && a.password == us.password );
        //   if (op == null)
        //    {
        //       return RedirectToAction("Create", "User");
        //    }
        //    else if (op != null)
        //    {
        //      return  RedirectToAction("Index", "User");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        public string GetSession()
        {
            var user =Convert.ToInt32(Session["User"].ToString());
            var LoginId= context.users.SingleOrDefault(a => a.id == user);

            return LoginId.firstname+LoginId.lastname;
        }

        public ActionResult ViewUser()
        {
            List<user> users = context.users.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
        
            var ed = context.users.SingleOrDefault(a => a.id == id);
            return View(ed);
         
        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_p(user us)
        {
            
            context.SaveChanges();
            return View();
        }


        //public ActionResult Delete(int id)
        //{
        //    ViewBag.username = GetLoginUser();
        //    user users = context.users.SingleOrDefault(a => a.id == id);
        //    return View(users);
        //}

     



    }
}
