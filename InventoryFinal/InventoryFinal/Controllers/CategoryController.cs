using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        InventoryDBContext context=new InventoryDBContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        [ActionName("Create")]

        public ActionResult Create_cat(category cat)
        {
            try
            {

                context.categories.Add(cat);
                context.SaveChanges();
                ModelState.Clear();
                cat = null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Category");
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult ViewCategory()
            {
                List<category> cat = context.categories.ToList();
                return View(cat);
            }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var ed = context.categories.SingleOrDefault(a => a.id == id);
            return View();

        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_p(user us)
        {

            context.SaveChanges();
            return View();
        }
    }
}
