using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey.Controllers.Api
{
    public class HomesController : Controller
    {
        //
        // GET: /Homes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Homes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Homes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Homes/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Homes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Homes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Homes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Homes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
