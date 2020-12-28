using System.Data.Entity;

namespace LibraryManagementApp_MVC.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base()
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}