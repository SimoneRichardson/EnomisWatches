using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnomisWatches.Controllers
{
    public class ShopController : BaseController
    {
       
        
        //db connection
        Models.ECommerceEntities db = new Models.ECommerceEntities();

        //
        // GET: /Shop/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ByProduct(int id){
           Models.Product product = db.Products.Find(id);
        
            return View(product);
                 
        }
    }
}
