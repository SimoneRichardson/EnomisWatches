using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnomisWatches.Controllers
{
    public class CartController : BaseController
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }
    //Get: /Cart/MiniCart
        public ActionResult MiniCart() 
        {
        //returns a partial view for use in the header.
            return PartialView(this.MyOrder);
        }
   
    //Get: /Cart/Add
        public ActionResult Add() 
        {
            return PartialView(this.MyOrder);
        }
   
    
       //
        // GET: /Cart/Remove/5

        public ActionResult Remove(int id = 0)
        {
          Item item = db.Item.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Cart/Remove/5

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            Item cart = db.item.Find(id);
            db.Item.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

    
    
    }

