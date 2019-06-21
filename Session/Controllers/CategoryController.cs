using Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _service;
            public CategoryController()
        {
            _service = new NorthwindEntities();
        }

        public ActionResult Index()
        {
            List<Category> categoryList = _service.Categories.ToList();
            return View(categoryList);
        }
    }
}