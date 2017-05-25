
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartTest.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartTest.Models;

namespace ShoppingCartTest.Tests
{
    [TestClass]
    public class ShoppingControllerTest
    {
        [TestMethod]
        public void TestView()
        {
            ShoppingController Controller = new ShoppingController();
            // ActionResult Result = Controller.Index(); 
            ViewResult Result = Controller.Index() as ViewResult;
            //IEnumerable<ShoppingCartItem> TestModel = Result.Model as IEnumerable<ShoppingCartItem>;
            Assert.AreEqual("Index", Result.ViewBag.Title);
            //Assert.AreEqual("Index", TestModel.ToString()); 
        }
    }
}
