using LibraryManagementApp_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryManagementApp_MVC.Controllers
{
    public class BookController : Controller
    {
        private static IList<Book> bookCollection = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Woman in Cabin 10",
                Author = "Ruth Ware",
                YearPublished = "2020"
            },
            new Book
            {
                Id = 2,
                Title = "The Lost Queen",
                Author = "Signe Pike",
                YearPublished = "2020"
            },
            new Book
            {
                Id = 3,
                Title = "Three Things About Elsie",
                Author = "Joanna Cannon",
                YearPublished = "2020"
            },
            new Book
            {
                Id = 4,
                Title = "The Library Book",
                Author = "Susan Orlean",
                YearPublished = "2020"
            },
            new Book
            {
                Id = 5,
                Title = "Watching You",
                Author = "Lisa Jewell",
                YearPublished = "2020"
            }
        };


        // GET: Book
        public ActionResult Index()
        {

            return View(bookCollection.OrderBy(b => b.Id).ToList());
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
                bookCollection.Add(book);

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

            var book = bookCollection.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var currentBook = bookCollection.FirstOrDefault(b => b.Id == updatedBook.Id);
                bookCollection.Remove(currentBook);

                bookCollection.Add(updatedBook);

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

            var book = bookCollection.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var currentBook = bookCollection.FirstOrDefault(b => b.Id == book.Id);
            bookCollection.Remove(currentBook);

            return RedirectToAction("Index");
        }

    }
}
