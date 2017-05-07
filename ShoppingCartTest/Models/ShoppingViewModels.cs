using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ShoppingCartTest.Models;
using System.Globalization; 

namespace ShoppingCartTest.Models
{

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public int OfferMinimumQty { get; set; }
        public double OfferPrice { get; set; }
        public string Image { get; set; }

        public double TotalPrice { get; set; }

        public string Currency { get; set; }

    }


    public class ShoppingModel
    {

        private ShoppingTestEntities db;
        private CultureInfo CultureInfo; 

        public ShoppingModel()
        {

            db = new ShoppingTestEntities();
            CultureInfo = CultureInfo.CurrentCulture;

            
        }

        public void Add(int CartId, int ProductId)
        {

            // Create new product. 
            var productNew = new Cart { CartId = CartId, ProductId = ProductId };

            // Check if product already exists in cart. 
            var product =
                from products in db.Carts
                where products.CartId == CartId &&
                products.ProductId == ProductId
                select products;

            if (product.ToList().Count > 0)
            {
                productNew.Quantity = product.First().Quantity + 1;
                db.Carts.Remove(product.First());
                db.SaveChanges();
            }
            else
                productNew.Quantity = 1;

            db.Carts.Add(productNew);
            db.SaveChanges();

            return;
        }

        public void Remove(int CartId, int ProductId)
        {

            // Create updated product. 
            var productUpdated = new Cart { CartId = CartId, ProductId = ProductId };

            // Check if product exists in cart. 
            var product =
                from products in db.Carts
                where products.CartId == CartId &&
                products.ProductId == ProductId
                select products;

            if (product.ToList().Count > 0)
            {
                // Create updated product quantity. 
                productUpdated.Quantity = product.First().Quantity - 1;

                // Remove existing product. 
                db.Carts.Remove(product.First());

                // Add updated product if it has a quantity. 
                if (productUpdated.Quantity > 0)
                    db.Carts.Add(productUpdated);

                db.SaveChanges();
            }

            return;
        }



        public IEnumerable<ShoppingCartItem> View()
        {

            // Get all product data.

            // IEnumerable<Cart> cart =
            // var cart =
            IEnumerable<ShoppingCartItem> shoppingCart =
                from products in db.Products
                where 
                products.Id == 1 ||
                products.Id == 2 ||
                products.Id == 3 ||
                products.Id == 4
                orderby products.Name
                // select carts;
                select new ShoppingCartItem
                {
                    ProductId = products.Id,
                    Name = products.Name,
                    Price = products.Price,

                    Image = products.Image, 

                    Currency = CultureInfo.NumberFormat.CurrencySymbol

                };




            //List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>
            //{
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 },
            //    new ShoppingCartItem { ProductId = 22, Quantity = 4 },
            //    new ShoppingCartItem { ProductId = 33, Quantity = 55 }
            //};

            //shoppingCart.Add(
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 }
            //);

            return(shoppingCart);
        }


        public IEnumerable<ShoppingCartItem> ViewBasket(int CartId)
        {

            // Get shopping cart data.

            // IEnumerable<Cart> cart =
            // var cart =
            IEnumerable<ShoppingCartItem> shoppingCart =
                from carts in db.Carts
                join products in db.Products on carts.ProductId equals products.Id
                where carts.CartId == CartId &&
                (
                carts.ProductId == 1 ||
                carts.ProductId == 2 ||
                carts.ProductId == 3 ||
                carts.ProductId == 4
                )
                orderby products.Name
                // select carts;
                select new ShoppingCartItem
                {
                    ProductId = products.Id,
                    Quantity = carts.Quantity,
                    Name = products.Name,
                    Price = products.Price,

                    OfferMinimumQty = products.OfferMinimumQty,
                    OfferPrice = products.OfferPrice,

                    Image = products.Image,

                    TotalPrice = products.OfferMinimumQty == 0 ?
                        carts.Quantity * products.Price :
                        (carts.Quantity / products.OfferMinimumQty * products.OfferPrice) +
                        (carts.Quantity % products.OfferMinimumQty * products.Price), 

                    Currency = CultureInfo.NumberFormat.CurrencySymbol

                };




            //List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>
            //{
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 },
            //    new ShoppingCartItem { ProductId = 22, Quantity = 4 },
            //    new ShoppingCartItem { ProductId = 33, Quantity = 55 }
            //};

            //shoppingCart.Add(
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 }
            //);

            return (shoppingCart);
        }


        public IEnumerable<ShoppingCartItem> ViewItem(int CartId, int ProductId)
        {

            // Get specific product data.

            // IEnumerable<Cart> cart =
            // var cart =
            IEnumerable<ShoppingCartItem> shoppingCart =
                from products in db.Products
                where
                products.Id == ProductId 
                orderby products.Name
                // select carts;
                select new ShoppingCartItem
                {
                    ProductId = products.Id,
                    Name = products.Name,
                    Price = products.Price,

                    OfferMinimumQty = products.OfferMinimumQty,
                    OfferPrice = products.OfferPrice,

                    Image = products.Image,

                    Currency = CultureInfo.NumberFormat.CurrencySymbol

                };




            //List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>
            //{
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 },
            //    new ShoppingCartItem { ProductId = 22, Quantity = 4 },
            //    new ShoppingCartItem { ProductId = 33, Quantity = 55 }
            //};

            //shoppingCart.Add(
            //    new ShoppingCartItem { ProductId = 1, Quantity = 2 }
            //);

            return (shoppingCart);
        }




    }


}
