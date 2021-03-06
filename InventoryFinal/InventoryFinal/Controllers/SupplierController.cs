﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
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
        public ActionResult Create_s(supplier supplier)
        {


            try
            {

                context.suppliers.Add(supplier);
                context.SaveChanges();
                ModelState.Clear();
                supplier = null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Supplier");
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Viewsupplier()
        {
            List<supplier> suppliers = context.suppliers.ToList();
            return View(suppliers);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var supp = context.suppliers.SingleOrDefault(a => a.id == id);
            return View(supp);

        }

        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_su(supplier supplier)
        {
            context.SaveChanges();
            return View(supplier);
        }

    }
    
}
