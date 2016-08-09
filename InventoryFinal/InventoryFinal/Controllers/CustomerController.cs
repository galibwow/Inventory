using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private InventoryDBContext context = new InventoryDBContext();

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
        public ActionResult Create_C(customer cu)
        {


            try
            {

                context.customers.Add(cu);
                context.SaveChanges();
                ModelState.Clear();
                cu = null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Customer");
            }
        }

        public ActionResult Edit(int id)
        {

            var ed = context.customers.SingleOrDefault(a => a.id == id);
            return View(ed);

        }

        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_p(customer cus)
        {

            context.SaveChanges();
            return View();
        }
        public ActionResult ViewUser()
        {
            List<customer> customers = context.customers.ToList();
            return View(customers);
        }

    }
}

