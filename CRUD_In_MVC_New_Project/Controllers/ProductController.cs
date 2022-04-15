using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_In_MVC_New_Project.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace CRUD_In_MVC_New_Project.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        public IActionResult List()
        {

            ViewBag.productList = context.GetAllProducts();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(IFormCollection fc)
        {
            Product p = new Product();
            p.name = fc["name"];
            p.price = Convert.ToDecimal(fc["price"]);
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");

            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = context.GetProductByid(id);
            ViewBag.name = prod.name;
            ViewBag.price = prod.price;
            ViewBag.id = prod.id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Product prod = new Product();
            prod.name = form["name"];
            prod.price = Convert.ToDecimal(form["price"]);
            prod.id = Convert.ToInt32(form["id"]);
            int res = context.Upate(prod);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = context.GetProductByid(id);
            ViewBag.name = prod.name;
            ViewBag.price = prod.price;
            ViewBag.id = prod.id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }


    }
}
