using LibraryManagementApp_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryManagementApp_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext db = new BookContext();


        // GET: Book
        public ActionResult Index()
        {

            return View(db.Books.ToList());
        }


        // GET: Book/Create
        public ActionResult Create()
        {
            Book book = new Book();

            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var currentBook = db.Books.FirstOrDefault(b => b.Id == updatedBook.Id);
                db.Books.Remove(currentBook);

                db.Books.Add(updatedBook);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(updatedBook);
        }



        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var currentBook = db.Books.FirstOrDefault(b => b.Id == book.Id);
            db.Books.Remove(currentBook);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
