using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class TaxController : Controller
    {
        //
        // GET: /Tax/
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
        public ActionResult Create_p(tax ta)
        {


            try
            {

                context.taxes.Add(ta);
                context.SaveChanges();
                ModelState.Clear();
                ta = null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Tax");
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult ViewTax()
        {
            List<tax> tax = context.taxes.ToList();
            return View(tax);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var ed = context.taxes.SingleOrDefault(a => a.id == id);
            return View(ed);

        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_t(tax ta)
        {

            context.SaveChanges();
            return View();
        }


    }
}
