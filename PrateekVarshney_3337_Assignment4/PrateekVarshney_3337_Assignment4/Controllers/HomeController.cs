using PrateekVarshney_3337_Assignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace PrateekVarshney_3337_Assignment4.Controllers
{
    public class HomeController : Controller
    {
        RetailStore retailContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            retailContext = new RetailStore();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult GetProductList()
        {
            // return View();
            return Json(retailContext.ProductList, JsonRequestBehavior.AllowGet);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                retailContext.ProductList.Add(product);
                retailContext.SaveChanges();
                return Json(retailContext.ProductList);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here

                Product tempProduct = retailContext.ProductList.Where(x => x.Id == product.Id).SingleOrDefault();

                if (tempProduct != null && product != null)
                {
                    retailContext.Entry(tempProduct).CurrentValues.SetValues(product);
                    retailContext.SaveChanges();
                }

                return Json(retailContext.ProductList);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                // TODO: Add delete logic here
                Product tempProduct = retailContext.ProductList.Where(x => x.Id == product.Id).SingleOrDefault();

                if (tempProduct != null && product != null)
                {
                    retailContext.ProductList.Remove(tempProduct);
                    retailContext.SaveChanges();
                }

                return Json(retailContext.ProductList);
            }
            catch
            {
                return View();
            }
        }
    }
}
