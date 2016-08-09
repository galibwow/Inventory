using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{

    public class BundleController : Controller
    {
        private InventoryDBContext context = new InventoryDBContext();
        //
        // GET: /Bundle/

        public ActionResult Index()
        {
            List<bundle_lot> bundle = context.bundle_lot.ToList();
            return View(bundle);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult Create_B(bundle_lot lot)
        {
            try
            {
                context.bundle_lot.Add(lot);
                context.SaveChanges();
                ModelState.Clear();
                lot = null;
                ViewBag.Message = "Successfully Registration Done";
                return RedirectToAction("Index", "Bundle");
            }
            catch (Exception e)
            {

                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var ed = context.bundle_lot.SingleOrDefault(a => a.id == id);
            return View(ed);

        }

        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_t(tax bu)
        {

            context.SaveChanges();
            return View();




        }

    }
}
