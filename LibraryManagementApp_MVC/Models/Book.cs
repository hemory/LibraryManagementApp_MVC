using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp_MVC.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Display(Name = "Year Published")]
        [Required]
        public string YearPublished { get; set; }
    }
}