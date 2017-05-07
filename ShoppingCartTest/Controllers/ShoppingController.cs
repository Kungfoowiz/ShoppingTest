using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartTest.Models;


namespace ShoppingCartTest.Controllers
{

    


    public class ShoppingController : Controller
    {





        public ActionResult Add(int CartId, int ProductId)
        {

            new ShoppingModel().Add(CartId, ProductId);

            //return Redirect("/Shopping/Index");
            return Redirect("/Shopping/ViewBasket");

        }

        // Remove product from cart. 
        public ActionResult Remove(int CartId, int ProductId)
        {

            new ShoppingModel().Remove(CartId, ProductId);

            //return Redirect("/Shopping/Index");
            return Redirect("/Shopping/ViewBasket");

        }

        // GET: Shopping
        public ActionResult Index()
        {
            
            return View(new ShoppingModel().View()); 
            
            //return View(cart); 

        }


        // GET: Shopping/ViewItem
        public ActionResult ViewItem(int CartId, int ProductId = 1)
        {

            return View(new ShoppingModel().ViewItem(CartId, ProductId));

        }


        // GET: Shopping/ViewBasket
        public ActionResult ViewBasket(int CartId = 1000)
        {

            return View(new ShoppingModel().ViewBasket(CartId));

        }


    }
}