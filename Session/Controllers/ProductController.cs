using PagedList;
using Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities _service;
        public ProductController()
        {
            _service = new NorthwindEntities();
        }



        public ActionResult Index(int? id, int page=1)
        {

            if (id == 0 || id==null)
            {
                return RedirectToAction("Index", "Category");
            }
            List<Product> productList = _service.Products.Where(x => x.CategoryID == id).ToList();

            return View(productList.ToPagedList(page,5));
        }
    }
}