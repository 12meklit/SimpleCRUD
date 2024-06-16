using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace ProjectWeb.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set;}
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int? CategoryId { get; set; }
        public int? TotalBook { get; set; }
        public int? BorrowdBook { get; set; }
        public DateTime? CreateDataTime { get; set; } = DateTime.Now;
        public int? LeftBook { get; set; }

        public virtual Category Category { get; set; }
    }
}
