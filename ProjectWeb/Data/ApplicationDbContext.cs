using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;
namespace ProjectWeb.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } //categories is the table name and category is the model class name
        public DbSet<Book> Bookes { get; set; }
        public DbSet<student> Students { get; set; }
        public DbSet<StudentBorrow> StudentBorrowes { get; set; }
      

    }
}
