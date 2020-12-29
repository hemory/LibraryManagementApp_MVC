using LibraryManagementApp_MVC.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryManagementApp_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext db = new BookContext();


        // GET: Book
        public ActionResult Index(string searchString)
        {

            var books = from b in db.Books
                select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Author.Contains(searchString));

            }
            return View(books.ToList());
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

            var book = db.Books.Find(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var currentBook = db.Books.Find(updatedBook.Id);
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

            var book = db.Books.Find(id);

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var currentBook = db.Books.Find(book.Id);
            db.Books.Remove(currentBook);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
