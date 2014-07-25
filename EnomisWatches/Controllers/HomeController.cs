﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnomisWatches.Controllers
{
    public class HomeController : Controller
    {

        //db connection
        Models.ECommerceEntities db = new Models.ECommerceEntities();
        
        public ActionResult Index()
        {
            //display all products on the landing page
            return View(db.Products.OrderByDescending(x=> x.ListPrice));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
