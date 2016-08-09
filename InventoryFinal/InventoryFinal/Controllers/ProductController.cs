using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class ProductController : Controller
    {
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
        public ActionResult Create_p(product p)
        {


            try
            {

                context.products.Add(p);
                context.SaveChanges();
                ModelState.Clear();
                p = null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Product");
            }
            catch (Exception)
            {

                return View();
            }
        }
        

        public ActionResult ViewProduct()
        {
            List<product> products = context.products.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var ed = context.products.SingleOrDefault(a => a.id == id);
            return View(ed);

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
