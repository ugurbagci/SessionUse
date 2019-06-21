using Session.Cart;
using Session.Models;
using Session.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class CartController : Controller
    {
        NorthwindEntities _service;
        public CartController()
        {
            _service = new NorthwindEntities();
        }
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<ProductVM> productList = cart.CartProductList.Select(x => new ProductVM
                {
                    Id= x.Id,
                    ProductName=x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    Quantity = x.Quantity

                }).ToList();
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);

        }

        public JsonResult Add(int id)
        {
            Product product = _service.Products.Find(id);

            ProductVM model = new ProductVM()
            {
                Id = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Quantity = 1
            };

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(model);
                Session["sepet"] = cart;
            }
            else
            {
                ProductCart cart = new ProductCart();
                cart.AddCart(model);
                Session.Add("sepet", cart);
            }

            return Json("");
        }

        public JsonResult IncreaseCart(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.IncreaseCart(id);
            Session["sepet"] = cart;
            return Json("");
        }
        public JsonResult DecreaseCart(int id)
        {
            if (Session["sepet"]!= null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json(""); 
        }
        public  JsonResult RemoveCart(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveCart(id);
            Session["sepet"] = cart;
            return Json("");
        }


    }
}