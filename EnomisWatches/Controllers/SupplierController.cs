using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnomisWatches.Controllers
{
    //Authorize data annotation requires a user
    //logged in to access anything in this controller
    //[Authorize()]
    //Limit access only to admin users
    [Authorize(Roles = "admin")]
    public class SupplierController : BaseController
    {
        //make a connnection to the database
        Models.ECommerceEntities db = new Models.ECommerceEntities();


        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            //the index will return all of the 
            //user's posts
            return View(db.Suppliers);
        }
        // Get: /Supplier/Create
        [HttpGet]
        public ActionResult Create()
        {
            //pass a blank post object to the view
            return View(new Models.Supplier());
        }
        //Post: /Supplier/Create
        [HttpPost]
        public ActionResult Create(Models.Supplier supplier)
        {
                 
            
            //add it to the database
            db.Suppliers.Add(supplier);
            //save our changes
            db.SaveChanges();
            //kick user back to their list of posts
            return RedirectToAction("Index", "Supplier");
        }
        //Get: /Supplier/Delete/(id)
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.Supplier supplierToDelete = db.Suppliers.Find(id);
            //pass the object to the view
            return View(supplierToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Supplier supplierToDelete = db.Suppliers.Find(id);
            //delete the supplier from the database
            db.Suppliers.Remove(supplierToDelete);
            //save the changes to the DB
            db.SaveChanges();
            //redirect the user 
            return RedirectToAction("Index", "Supplier");
        }
        //Get: /Supplier/Edit/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //get the supplier to edit from the db
            Models.Supplier supplierToEdit = db.Suppliers.Find(id);
            //pass our supplier to edit to the view
            return View (supplierToEdit);
        }
        //Supplier: /Supplier/Edit/1
        [HttpPost]
        public ActionResult Edit(Models.Supplier supplierToEdit)
        {
            //Set the supplier to be updated
            db.Entry(supplierToEdit).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();
            //kick the user back to their post list
            return RedirectToAction("Index", "Supplier");
        }
    }
}
