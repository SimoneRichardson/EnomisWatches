using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnomisWatches.Controllers
{
    public class BaseController : Controller
    {
        //property to get our order
        private Models.Order _myOrder;
        public Models.Order MyOrder
        {
            get
            {
                //see if _myOrder is null
                if (_myOrder == null)
                {
                    //get the order from the database
                    _myOrder = db.Orders.Find(GetOrderId());
                }
                return _myOrder;
            }
        }
        
        //Setup a database connection
       public Models.ECommerceEntities db = new Models.ECommerceEntities();

        //public
        public int GetOrderId()
        { 
        if (Session["OrderID"] == null)
        {
  //they dont have a orderID
            //create a new order


           //Step 1: make a new order object
            Models.Order order = new Models.Order();
            //Step 2: fill in required information
            order.DateCreated = DateTime.Now;
            order.Status = "Cart";
            order.Tax = 0;
            order.Total = 0;
            order.ShippingTotal = 0;
            //Step 3: add order to the database
            db.Orders.Add(order);
            //Step 4: save changes
            db.SaveChanges();
            //Step 5: set the session variable
            //for the orderID
            Session["OrderID"] = order.OrderID;
        }
            return int.Parse(Session["OrderID"].ToString());
        }
    }
}
