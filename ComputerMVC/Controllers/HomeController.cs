using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputersDBCW.Models;
using ComputersDBCW.Context;
using System.Data.Entity;

namespace ComputerMVC.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            return View(db.Computers);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult EditComputer(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Computers computers = db.Computers.Find(id);
            if (computers != null)
            {
                return View(computers);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditComputer(Computers computers)
        {
            db.Entry(computers).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Computers computers)
        {
            db.Computers.Add(computers);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Computers b = db.Computers.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Computers b = db.Computers.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Computers.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}