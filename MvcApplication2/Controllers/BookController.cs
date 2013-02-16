using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class BookController : Controller
    {
        private BookEntityContainer db = new BookEntityContainer();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Single(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.AddObject(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Single(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Attach(book);
                db.ObjectStateManager.ChangeObjectState(book, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Single(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Single(b => b.Id == id);
            db.Books.DeleteObject(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}