﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryFinal.Models;

namespace InventoryFinal.Controllers
{
    public class DamageController : Controller
    {
        //
        // GET: /Damage/
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
        public ActionResult Create_p(damaged_products damaged)
        {


            try
            {

                context.damaged_products.Add(damaged);
                context.SaveChanges();
                ModelState.Clear();
                damaged= null;
                ViewBag.Message = "Successfully Registration Done";

                return RedirectToAction("Index", "Damage");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Viewdamage()
        {
            List<damaged_products> damaged = context.damaged_products.ToList();
            return View(damaged);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var ed = context.damaged_products.SingleOrDefault(a => a.id == id);
            return View(ed);

        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_p(damaged_products damaged)
        {

            context.SaveChanges();
            return View();
        }


    }
}
