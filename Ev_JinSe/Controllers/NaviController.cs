using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ev_JinSe.Controllers
{
    public class NaviController : Controller
    {
        //
        // GET: /Navi/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Navi/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Navi/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Navi/Create

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
        // GET: /Navi/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Navi/Edit/5

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
        // GET: /Navi/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Navi/Delete/5

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
